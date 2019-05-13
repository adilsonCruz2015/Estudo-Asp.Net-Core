

namespace ADC_Movie.Domain.Interfaces
{
    public interface IOperation<T> where T: class
    {
        void Apply(ref T value);

        void Undo(ref T value);
    }
}
