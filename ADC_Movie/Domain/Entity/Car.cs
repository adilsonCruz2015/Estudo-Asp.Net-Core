

namespace ADC_Movie.Domain.Entity
{
    public class Car : Entity.Comum.Entity
    {
        public string Name { get; set; }

        public Car(string name)
        {
            Name = name;
        }
    }
}
