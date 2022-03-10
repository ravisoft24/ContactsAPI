using RoomsAPI.Data;
using System;
using System.Collections.Generic;

#nullable disable

namespace RoomsAPI.Models
{
    public partial class RoomModel
    {
        public int Id { get; set; }
        public string RoomNo { get; set; }
        public string Type { get; set; }
        public string PriceLbl { get; set; }
        public string Status { get; set; }
        public IList<RoomFeatures> RoomFeatures { get; set; }

    }
}
