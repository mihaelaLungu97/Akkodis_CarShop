using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop_RoxanaLungu.Models
{
    public class Client
    {
        #region Properties
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? ClientId { get; set; }
        public string? Name { get; set; }
        public string? CNP { get; set; }
        public List<Car>? Cars { get; set;}
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"{Name} ({CNP})";
        }
        #endregion

    }
}
