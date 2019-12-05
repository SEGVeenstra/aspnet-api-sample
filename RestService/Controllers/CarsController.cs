using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestService.Models;
using System.Collections;
using RestService.DTOs.Cars;

namespace RestService.Controllers
{
    [Route("api/[controller]")]
    public class CarsController : Controller
    {
        private IList<Car> cars = new List<Car>();

        // GET api/cars
        [HttpGet]
        public IEnumerable<CarGET> Get()
        {
            return cars.Select(car => new CarGET {
                Id = car.Id,
                Name = car.Name,
                Brand = car.Brand,
                Color = car.Color
            });
        }

        // GET api/cars/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var selectedCar = cars.FirstOrDefault(c => c.Id == id);

            if (selectedCar == null)
                return NotFound();

            var car = new CarGET {
                Id = selectedCar.Id,
                Name = selectedCar.Name,
                Brand = selectedCar.Brand,
                Color = selectedCar.Color
            };

            return Ok(car);
        }

        // POST api/cars
        [HttpPost]
        public void Post([FromBody]CarPOST car)
        {
            cars.Add(new Car (GenerateId(), car.Name,car.Brand,car.Color));
        }

        // PUT api/cars/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]CarPUT car)
        {
            var selectedCar = cars.FirstOrDefault(c => c.Id == id);

            if (selectedCar == null)
                return NotFound();

            cars.Remove(selectedCar);
            cars.Add(new Car(id, car.Name, car.Brand, car.Color));
            return NoContent();
        }

        // PUT api/cars/5
        [HttpPatch("{id}")]
        public void Patch(int id, [FromBody]string value)
        {

        }

        // DELETE api/cars/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        private int GenerateId()
        {
            if (cars.Count() == 0) return 1;
            else return cars.OrderByDescending(car => car.Id).First().Id + 1;
        }
    }
}
