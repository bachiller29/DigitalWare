using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DigitalWare.Model.Models
{
    public partial class SalesClient
    {
        [Key]
        public int IdSalesClient { get; set; }
        public int? IdSales { get; set; }
        public long? IdClient { get; set; }

        public Client IdClientNavigation { get; set; }
        public Sales IdSalesNavigation { get; set; }
    }
}
