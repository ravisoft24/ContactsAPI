using System.Collections.Generic;

namespace RoomsAPI.Data
{
    public class Rooms
    {
        public int Id { get; set; }
        public string RoomNo { get; set; }
        public string Type { get; set; }
        public string PriceLbl { get; set; }
        public string Status { get; set; }
        public IList<RoomFeatures> RoomFeatures { get; set; }

    }
}
