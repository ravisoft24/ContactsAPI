using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using ReservationsAPI.Data;
using ReservationsAPI.Models;
using RoomsAPI.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReservationsAPI.Repository
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly ReservationContext _context;
        private readonly IMapper _mapper;

        public ReservationRepository(ReservationContext context, IMapper mapper )
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ReservationModel>> GetAllReservations()
        {
            var reservations = await _context.Reservations.ToListAsync();
            return _mapper.Map<List<ReservationModel>>(reservations);

        }

        public async Task<ReservationModel> GetReservationById(int id)
        {
            var reservation = await _context.Reservations.FindAsync(id);
            return _mapper.Map<ReservationModel>(reservation);

        }


        public async Task<int> AddNewReservationAsync(ReservationModel reservationModel)
        {
            reservationModel.Status = "Confirmed";
            var mapper = _mapper.Map<Reservations>(reservationModel);
            _context.Reservations.Add(mapper);
            await _context.SaveChangesAsync();
            return mapper.Id;
        }


        public async Task<int> UpdateReservationAsync(int id, ReservationModel reservationModel)
        {
            var reservation = new Reservations()
            {
                Id = id,
                FirstName = reservationModel.FirstName,
                LastName = reservationModel.LastName,
                Email = reservationModel.Email,
                Property = reservationModel.Property,  
                Room = reservationModel.Room

            };
            _context.Reservations.Update(reservation);
            await _context.SaveChangesAsync();
            return reservation.Id;
        }


        public async Task UpdateReservationPatchAsync(int id, JsonPatchDocument reservationModel)
        {
            var reservation = _context.Reservations.Find(id);
            if (reservation != null)
            {
                reservationModel.ApplyTo(reservation);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteFeatureAsync(int resId)
        {
            var reservation = new Reservations() { Id = resId };

            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();

        }


        public async Task<int> Manage(int id, JsonPatchDocument reservationModel)
        {
            
            var reservation = _context.Reservations.Find(id);
            if (reservation != null)
            {
                reservationModel.ApplyTo(reservation);
                await _context.SaveChangesAsync();
                return reservation.Room;

            }
            return reservation.Room;
        }

            public async Task<int> CheckIn(int id)
        {
            /*
            var reservation = _context.Reservations.Find(id);
            if (reservation != null)
            {
                reservationModel.ApplyTo(reservation);
                await _context.SaveChangesAsync();
                return reservation.Room;

            }
            return reservation.Room;
            */

            var reservation = _context.Reservations.Find(id);
            if (reservation != null)
            {
                _context.Reservations.Attach(reservation);
                reservation.Status = "Checked-In";
                _context.Entry(reservation).Property("Status").IsModified = true;
                _context.SaveChanges();
                
            }
            return reservation.Room;
        }

        public async Task<int> CheckOut(int id)
        {
            var reservation = _context.Reservations.Find(id);
            if (reservation != null)
            {
                _context.Reservations.Attach(reservation);
                reservation.Status = "Checked-Out";
                _context.Entry(reservation).Property("Status").IsModified = true;
                _context.SaveChanges();

            }
            return reservation.Room;


        }

    }
}
