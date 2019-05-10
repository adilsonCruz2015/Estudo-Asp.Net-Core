

namespace ADC_Back.Validation
{
    public class Notification
    {
        public string Key { get; }

        public string Message { get; }

        public string Referencia { get; }

        public object Valor { get; }



        public Notification(string key, string message, string referencia, object valor)
        {
            Key = key;
            Message = message;
            Referencia = referencia;
            Valor = valor;
        }
    }
}
