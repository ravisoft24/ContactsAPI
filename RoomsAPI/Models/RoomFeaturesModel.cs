using RoomsAPI.Data;

namespace RoomsAPI.Models
{
    public class RoomFeaturesModel
    {
        public Rooms Room { get; set; }
        public int RoomId { get; set; }
        public Features Features { get; set; }
        public int FeaturesId { get; set; }
    }
}
