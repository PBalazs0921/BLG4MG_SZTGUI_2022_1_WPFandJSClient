using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BLG4MG_HFT_2021222.Models
{
    public class Brand
    {

        [Key]
        public int BrandId { get; set; }

        public string BrandName { get; set; }

        public string Contact { get; set; }

        [JsonIgnore]
        public virtual ICollection<Car> Cars { get; set; }

        public Brand()
        {
            Cars = new HashSet<Car>();
        }
    }
}
