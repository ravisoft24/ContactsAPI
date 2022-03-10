using System;

namespace ReservationsAPI.Models
{
    public class ReservationModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int Property { get; set; }
        public int Room { get; set; }
        public string Status { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

    }
}
