using App.Domain.Entities;
using App.Domain.Interfaces.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PessoaController : Controller
    {
        private IPessoaService _service;

        public PessoaController(IPessoaService service)
        {
            _service = service;
        }

        [HttpGet("ListarPessoas")]
        public JsonResult ListaPessoas()
        {
            return Json(_service.listaPessoas());
        }
        [HttpGet("BuscarPorId")]
        public JsonResult BuscarPorId(Guid id)
        {
            return Json(_service.BuscaPorId(id));
        }
        [HttpPost("Salvar")]
        public JsonResult Salvar(string nome, int peso, DateTime dataNascimento, bool ativo, Guid idCidade)
        {
            var obj = new Pessoa
            {
                Nome = nome,
                DataNascimento = dataNascimento,
                Peso = peso,
                Ativo = ativo,
                CidadeId = idCidade,
                 
            };
            _service.Salvar(obj);
            return Json(true);
        }
        //httpPost = pode fazer mais de uma requisicao.
        //httpDelete = faz apenas a requisicao de deletar.
        [HttpPost("Delete")]
        public JsonResult Remover(Guid id)
        {


            _service.Remover(id);
            return Json(true);

        }
    }
}
