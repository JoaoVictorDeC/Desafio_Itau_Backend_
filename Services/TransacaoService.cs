using Desafio_Itau_backend_C_.DTO;
using Desafio_Itau_backend_C_.Helpers;
using Desafio_Itau_backend_C_.Repository;
using Desafio_Itau_backend_C_.Models;

namespace Desafio_Itau_backend_C_.Services
{
    public class TransacaoService
    {
        private readonly TransacaoRepository repository;

        public TransacaoService (TransacaoRepository _repository) 
        {
            repository = _repository;
        }

        public void CriarTransacao(TransacaoRequest transacao) 
        {
            if (transacao.Valor == 0) 
            {
                throw new ArgumentException("O valor deve ser maior do que zero");
            }

            repository.Add(transacao);
        }

        public void LimparService() 
        {

            if (repository == null)
                throw new InvalidOperationException("Repositório não foi inicializado.");

            repository.Limpar();

        }
        public EstatisticaDTO ObterEstatisticas(DateTimeOffset horaInicial) 
        {
            var valores = repository.ObterEstasitiscas(horaInicial);
            if (!valores.Any())
            {
                return new EstatisticaDTO();
            }

            var estatistica = new DoubleSummaryStatics();
            foreach (var valor in valores) 
            {
                estatistica.Add(valor);
            }


            return new EstatisticaDTO(estatistica);
        }
    }
}
