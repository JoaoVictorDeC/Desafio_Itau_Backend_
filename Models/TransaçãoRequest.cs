using Desafio_Itau_backend_C_.Services;
using Microsoft.AspNetCore.Mvc;

namespace Desafio_Itau_backend_C_.Models
{
    public class TransacaoRequest
    {
        public double Valor { get; private set; }
        public DateTimeOffset HoraInicial { get; private set; }

        public  TransacaoRequest(double valor, DateTimeOffset horainicial)
        {
            Valor = valor;
            HoraInicial = horainicial;

        }

    };    
}
