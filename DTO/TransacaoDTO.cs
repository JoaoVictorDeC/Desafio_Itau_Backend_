using Desafio_Itau_backend_C_.Models;

namespace Desafio_Itau_backend_C_.DTO;

        // Para transportar dados de entrada
        public class TransacaoRequest
        {
            public double Valor { get; set; }
            public DateTimeOffset DataHora { get; set; }
            public string Descricao { get; set; }
        }

        // Para transportar estatísticas de saída
      
   
 