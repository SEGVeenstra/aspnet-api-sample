namespace RestService.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; private set; }
        public string Color { get; private set; }
        public string Name { get; private set; }

        public Car(int id, string name, string brand, string color)
        {
            this.Id = id;
            this.Name = name;
            this.Color = color;
            this.Brand = brand;
        }
    }
}
