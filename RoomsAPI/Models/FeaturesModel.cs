using RoomsAPI.Data;
using System.Collections.Generic;

namespace RoomsAPI.Models
{
    public class FeaturesModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<RoomFeatures> RoomFeatures { get; set; }


    }
}
