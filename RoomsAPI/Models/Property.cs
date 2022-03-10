using System;
using System.Collections.Generic;

#nullable disable

namespace RoomsAPI.Models
{
    public partial class Property
    {
        public int Id { get; set; }
        public string Chain { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }
    }
}
