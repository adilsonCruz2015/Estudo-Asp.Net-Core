using System;

namespace ADC_Movie.Domain.Entity
{
    public class Address : Comum.Entity
    {
        public string Rua { get; set; }

        public Address()
        {
            Id = Guid.NewGuid();
        }

        public Address(string rua)
            :this()
        {
            Rua = rua;
        }
    }
}
