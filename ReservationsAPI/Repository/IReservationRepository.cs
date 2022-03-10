using Microsoft.AspNetCore.JsonPatch;
using ReservationsAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReservationsAPI.Repository
{
    public interface IReservationRepository
    {
        Task<List<ReservationModel>> GetAllReservations();
        Task<ReservationModel> GetReservationById(int id);
        Task<int> AddNewReservationAsync(ReservationModel reservationModel);
        Task<int> UpdateReservationAsync(int id, ReservationModel reservationModel);
        Task UpdateReservationPatchAsync(int id, JsonPatchDocument reservationModel);
        Task DeleteFeatureAsync(int resId);
        Task<int> Manage(int id, JsonPatchDocument reservationModel);
        Task<int> CheckIn(int id);
        Task<int> CheckOut(int id);
        
    }
}
