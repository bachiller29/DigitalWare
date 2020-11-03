using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalWare.Model.Models
{
    public partial class Inventory
    {
        [Key]
        [Column("id_inventory")]
        public int IdInventory { get; set; }

        [Column("quantity")]
        public long? Quantity { get; set; }

        [Column("id_produc")]
        public int IdProduc { get; set; }

        public Products IdProducNavigation { get; set; }
    }
}
