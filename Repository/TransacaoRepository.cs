using Desafio_Itau_backend_C_.DTO;
using Desafio_Itau_backend_C_.Helpers;
using Desafio_Itau_backend_C_.Models;
using Microsoft.OpenApi.Any;

namespace Desafio_Itau_backend_C_.Repository
{
    public class TransacaoRepository
    {
        //Criando repositorio em Memória para guardar dados
        private List<TransacaoRequest> _Repository = new List<TransacaoRequest> ();

        public void Add(TransacaoRequest transacao) 
        {
            _Repository.Add(transacao);
        }

        public void Limpar() 
        {
            _Repository.Clear();
        }

        public List<double> ObterEstasitiscas(DateTimeOffset horaInicial) 
        {
            //Filtramos os valores pela data maior ou igual a hora selecionada
            return _Repository.
                Where(t => t.HoraInicial >= horaInicial).
                Select(t => t.Valor).
                ToList();
        }
    }

}

