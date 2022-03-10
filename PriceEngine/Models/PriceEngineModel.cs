using System;

namespace PriceEngine.Models
{
    public class PriceEngineModel
    {
        public int Id { get; set; }
        public string PriceLbl { get; set; }
        public decimal Price { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}
