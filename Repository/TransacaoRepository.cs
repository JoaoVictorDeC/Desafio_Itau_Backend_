using Desafio_Itau_backend_C_.DTO;
using Desafio_Itau_backend_C_.Helpers;
using Desafio_Itau_backend_C_.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Any;

namespace Desafio_Itau_backend_C_.Repository
{
    public class TransacaoRepository
    {
        //Criando repositorio em Memória para guardar dados
        private List<TransacaoRequest> _Repository = new List<TransacaoRequest> ();
   
        public Task CriarTransacao(TransacaoRequest transacao)
        {
            if (transacao.Valor <= 0)
                throw new ArgumentException("O valor deve ser maior que zero");

             _Repository.Add (transacao);
           
            return Task.CompletedTask; 
        }
        public List<TransacaoRequest> TodasTransacoes()
        {
            return _Repository.ToList();
        }


        public void Limpar() 
        {
            _Repository.Clear();
        }

        public Task<List<TransacaoRequest>> ObterEstatisticas(DateTimeOffset horaInicial)
        {
            var filtradas = _Repository.Where(t => t.HoraInicial >= horaInicial).ToList();
            return  Task.FromResult(filtradas);
        }

    }

}

