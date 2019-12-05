using System.ComponentModel.DataAnnotations;

namespace RestService.DTOs.Cars
{
    public class CarPUT
    {
        [Required]
        public string Brand { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
