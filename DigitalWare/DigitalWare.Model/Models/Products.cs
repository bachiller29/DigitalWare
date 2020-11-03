using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalWare.Model.Models
{
    public partial class Products
    {
        public Products()
        {
            Inventory = new HashSet<Inventory>();
            SalesProduct = new HashSet<SalesProduct>();
        }

        [Key]
        [Column("id_produc")]
        public int IdProduc { get; set; }

        [Column("name_product")]
        public string NameProduct { get; set; }

        [Column("price_product")]
        public long? PriceProduct { get; set; }

        [Column("description_produc")]
        public string DescriptionProduc { get; set; }

        public ICollection<Inventory> Inventory { get; set; }
        public ICollection<SalesProduct> SalesProduct { get; set; }
    }
}
