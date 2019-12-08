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
        static private IList<Car> cars = new List<Car>();

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
        public IActionResult Post([FromBody]CarPOST car)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            cars.Add(new Car (GenerateId(), car.Name,car.Brand,car.Color));
            return Ok();
        }

        // PUT api/cars/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]CarPUT car)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var selectedCar = cars.FirstOrDefault(c => c.Id == id);

            if (selectedCar == null)
                return NotFound();

            cars.Remove(selectedCar);
            cars.Add(new Car(id, car.Name, car.Brand, car.Color));
            return NoContent();
        }

        // PUT api/cars/5
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody]CarPATCH car)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var selectedCar = cars.FirstOrDefault(c => c.Id == id);

            if (selectedCar == null)
                return NotFound();

            cars.Remove(selectedCar);
            cars.Add(new Car(id, selectedCar.Name, selectedCar.Brand, car.Color));

            return Ok();
        }

        // DELETE api/cars/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var selectedCar = cars.FirstOrDefault(c => c.Id == id);

            if (selectedCar == null)
                return NotFound();

            cars.Remove(selectedCar);
            return Ok(selectedCar);
        }

        private int GenerateId()
        {
            if (cars.Count() == 0) return 1;
            else return cars.OrderByDescending(car => car.Id).First().Id + 1;
        }
    }
}
