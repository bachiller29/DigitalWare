using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DigitalWare.Model.Models
{
    public partial class SalesProduct
    {
        [Key]
        public int IdSalesProduct { get; set; }
        public int? IdSales { get; set; }
        public int IdProduc { get; set; }
        public int Quantify { get; set; }

        public Products IdProducNavigation { get; set; }
        public Sales IdSalesNavigation { get; set; }
    }
}
