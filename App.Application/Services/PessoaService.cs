using App.Domain.Entities;
using App.Domain.Interfaces.Application;
using App.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Services
{
    public class PessoaService : IPessoaService
    {
        private IRepositoryBase<Pessoa> _repository { get; set; }
        public PessoaService(IRepositoryBase<Pessoa> repository)
        {
            _repository = repository;
        }
        public Pessoa BuscaPorId(Guid id)
        {
           // throw new NotImplementedException();
            var obj = _repository.Query(x => x.Id == id).FirstOrDefault();
            return obj;
        }

        public List<Pessoa> listaPessoas(string nome, int pesoMaiorque, int pesoMenorQue)
        { //x.nome.contains
            nome = (nome ?? "");

            return _repository.Query(x => x.Nome.ToUpper().Contains(nome.ToUpper()) 
            && (pesoMaiorque == 0 || x.Peso >= pesoMaiorque)
            && (pesoMenorQue == 0 || x.Peso <= pesoMenorQue))
            .Select(p => new Pessoa
          {
              
              Id = p.Id,
              Nome = p.Nome,
              DataNascimento = p.DataNascimento,
              Peso = p.Peso,
              Ativo = p.Ativo,
              Cidade = new Cidade
              {
                  Nome = p.Cidade.Nome,
                  Id = p.Cidade.Id,
              }

          }).OrderByDescending(x => x.Nome).ToList();
        }
        public void Salvar (Pessoa obj)
        {
            if (string.IsNullOrEmpty(obj.Nome))
            {
                throw new Exception("Informe o Nome ");
            }
            _repository.Save(obj);
            _repository.SaveChanges();
        }
        public void Remover(Guid id)
        {
            _repository.Delete(id);
            _repository.SaveChanges();
        }
    }
}
