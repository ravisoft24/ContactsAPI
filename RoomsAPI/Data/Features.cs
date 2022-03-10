﻿using System.Collections.Generic;

namespace RoomsAPI.Data
{
    public class Features
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<RoomFeatures> RoomFeatures { get; set; }

    }
}
