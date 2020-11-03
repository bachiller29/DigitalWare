using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalWare.Model.Models
{
    public partial class Client
    {
        public Client()
        {
            SalesClient = new HashSet<SalesClient>();
        }

        [Key]
        [Column("id_client")]
        public long IdClient { get; set; }

        [Column("name_client")]
        public string NameClient { get; set; }

        [Column("identification_number")]
        public long? IdentificationNumber { get; set; }

        [Column("age")]
        public int? Age { get; set; }

        [Column("telephone")]
        public long? Telephone { get; set; }

        public ICollection<SalesClient> SalesClient { get; set; }
    }
}
