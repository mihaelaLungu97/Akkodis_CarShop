using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop_RoxanaLungu.Models
{
    public class Car
    {
        #region Properties
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? RegistrationNumber { get; set; }
        public string? VIN { get; set; }
        public string? Brand { get; set; }
        public Client? Client { get; set; }
        public int ClientId { get; set; }
        #endregion
    }
}
