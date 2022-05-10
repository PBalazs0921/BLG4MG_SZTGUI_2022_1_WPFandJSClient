using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLG4MG_HFT_2021222.Models
{
    public class Car
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public string Model { get; set; }
        public int BrandId { get; set; }
        public virtual Brand Brand { get; set; }

        public virtual ICollection<Rent> Rents { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }

        public int Cost { get; set; }

        public Car()
        {

        }


    }
}
