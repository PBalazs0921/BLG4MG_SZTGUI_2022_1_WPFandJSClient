using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BLG4MG_HFT_2021222.Models
{
    public class Rent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public DateTime begin { get; set; }

        public DateTime end { get; set; }

        public int CarId { get; set; }

        [JsonIgnore]
        public virtual Car car { get; set; }


        public int CustomerId { get; set; }

        public virtual Customer customer { get; set; }

        public Rent()
        {

        }

    }
}
