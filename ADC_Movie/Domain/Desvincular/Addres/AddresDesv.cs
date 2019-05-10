

namespace ADC_Movie.Domain.Desvincular.Addres
{
    public class AddresDesv
    {
        public  object Completo(Entity.Address address)
        {
            if (Equals(address, null))
                return null;

            return new
            {
                Id = address.Id,
                Rua = address.Rua
            };
        }
    }
}
