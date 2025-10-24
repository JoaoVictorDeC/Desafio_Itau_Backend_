using Desafio_Itau_backend_C_.DTO;
using Desafio_Itau_backend_C_.Helpers;
using Desafio_Itau_backend_C_.Models;
using Microsoft.OpenApi.Any;

namespace Desafio_Itau_backend_C_.Repository
{
    public class TransaçãoRepository
    {
        //Criando repositorio em Memória para guardar dados
        private List<Models.TransacaoRequest> _Repository = new List<Models.TransacaoRequest> ();

        public void Add(Models.TransacaoRequest transacao) 
        {
            _Repository.Add(transacao);
        }

        public void Limpar() 
        {
            _Repository.Clear();
        }

        new DTO.EstatisticaDTO ObterEstasitiscas(DateTimeOffset horaInicial) 
        {
            //Verifica se já existe um repository criado
            if (!_Repository.Any()) 
            {
                return new EstatisticaDTO();
            }
            //Filtramos os valores pela data maior ou igual a hora selecionada
            var valoresFiltrados = _Repository.
                Where(t => t.getDataHora() >= horaInicial).
                Select(t => t.getValor()).
                ToList();

            var estastiticas = new DoubleSummaryStatics();

            foreach (double valor in valoresFiltrados)
            {
                estastiticas.Add(valor);  
            }

            return new EstatisticaDTO(estastiticas);

        }
    }

}

