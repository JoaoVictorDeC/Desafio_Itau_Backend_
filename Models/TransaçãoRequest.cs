namespace Desafio_Itau_backend_C_.Models
{
    public class TransacaoRequest
    {
        private decimal _valor;
        private DateTimeOffset _dataHora;

        public  decimal getValor()
        {
            return _valor;
        }

        public DateTimeOffset getDataHora()
        {
            return _dataHora;
        }



    };

    
}
