using Desafio_Itau_backend_C_.DTO;
using Desafio_Itau_backend_C_.Helpers;
using Desafio_Itau_backend_C_.Repository;
using Desafio_Itau_backend_C_.Models;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace Desafio_Itau_backend_C_.Services
{
    public class TransacaoService
    {
        private readonly TransacaoRepository _repository;

        public TransacaoService (TransacaoRepository repository) 
        {
            _repository = repository;
        }

        public async Task CriarTransacao(TransacaoRequest transacao) 
        {
            if (transacao.Valor == 0) 
            {
                throw new ArgumentException("O valor deve ser maior do que zero");
            }

           await _repository.CriarTransacao(transacao);
        }
        
        public List<TransacaoRequest> ObterTransacoes()
        {
            return _repository.TodasTransacoes();
        }

        public void LimparService() 
        {

            if (_repository == null)
                throw new InvalidOperationException("Repositório não foi inicializado.");

            _repository.Limpar();

        }
        public async Task<EstatisticaDTO> ObterEstatisticas(DateTimeOffset horaInicial) 
        {
            var valores = await _repository.ObterEstatisticas(horaInicial);
            if (!valores.Any())
            {
                return new EstatisticaDTO();
            }

            var estatistica = new DoubleSummaryStatics();
            foreach (var t in valores) 
            {
                estatistica.Add(t.Valor);
            }
            
            return new EstatisticaDTO(estatistica);
        }
    }
}
