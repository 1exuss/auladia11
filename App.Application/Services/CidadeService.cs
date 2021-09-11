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
    public class CidadeService : ICidadeService
    {
        private IRepositoryBase<Cidade> _repository { get; set; }
        public CidadeService(IRepositoryBase<Cidade> repository)
        {
            _repository = repository;
        }
        public Cidade BuscaPorId(Guid id)
        {
            var obj = _repository.Query(x => x.Id == id).FirstOrDefault();
            return obj;
        }

        public List<Cidade> listaCidades()
        {
            return _repository.Query(x => 1 == 1).ToList();
        }
        public void Salvar(Cidade obj)
        {
            if (string.IsNullOrEmpty(obj.Nome))
            {
                throw new Exception("Informe o Nome ");
            }
            else if (string.IsNullOrEmpty(obj.Cep))
            {
                throw new Exception("Informe o CEP ");
            }
            else if (string.IsNullOrEmpty(obj.Uf))
            {
                throw new Exception("Informe o UF ");
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
