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
    public class Customer
    {
        public Customer()
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public virtual ICollection<Car> Cars { get; set; }

        [JsonIgnore]
        public virtual ICollection<Rent> Rents { get; set; }

    }
}
