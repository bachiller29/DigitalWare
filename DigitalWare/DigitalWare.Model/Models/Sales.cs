using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalWare.Model.Models
{
    public partial class Sales
    {
        public Sales()
        {
            SalesClient = new HashSet<SalesClient>();
            SalesProduct = new HashSet<SalesProduct>();
        }

        [Key]
        [Column("id_sales")]
        public int IdSales { get; set; }

        [Column("store_name")]
        public string StoreName { get; set; }

        [Column("date_sales")]
        public DateTime? DateSales { get; set; }

        [Column("value_total")]
        public long? ValueTotal { get; set; }

        [Column("id_inventory")]
        public int IdInventory { get; set; }

        public ICollection<SalesClient> SalesClient { get; set; }
        public ICollection<SalesProduct> SalesProduct { get; set; }
    }
}
