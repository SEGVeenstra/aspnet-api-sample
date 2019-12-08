using System.ComponentModel.DataAnnotations;

namespace RestService.DTOs.Cars
{
    public class CarPATCH
    {
        [Required]
        public string Color { get; set; }
    }
}
