using App.Domain.DTO;
using App.Domain.Entities;
using App.Domain.Interfaces.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

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

        [HttpGet("ListaPessoas")]
        public JsonResult ListaPessoas(string nome, int pesoMaiorQue, int pesoMenorQue)
        {
            return Json(_service.listaPessoas(nome, pesoMaiorQue, pesoMenorQue));
        }

        [HttpGet("BuscaPorId")]
        [AllowAnonymous]
        public JsonResult BuscaPorId(Guid id)
        {
            try
            {
                var obj = _service.BuscaPorId(id);
                return Json(RetornoApi.Sucesso(obj));
            }
            catch (Exception ex)
            {
                return Json(RetornoApi.Erro(ex.Message));
            }
            //  return Json(_service.BuscaPorId(id));
        }
        [HttpPost("Salvar")]
        [AllowAnonymous]
        public JsonResult Salvar(string nome, int peso, DateTime dataNascimento, bool ativo, Guid idCidade)
        {
            try
            {
                var obj = new Pessoa
                {
                    Nome = nome,
                    DataNascimento = dataNascimento,
                    Peso = peso,
                    Ativo = ativo,
                    CidadeId = idCidade
                };
                _service.Salvar(obj);
                return Json(RetornoApi.Sucesso(obj));
            }
            catch (Exception ex)
            {
                return Json(RetornoApi.Erro(ex.Message));
            }
        }
        //var obj = new Pessoa
        // {
        //      Nome = nome,
        //    DataNascimento = dataNascimento,
        //   Peso = peso,
        //    Ativo = ativo,
        //  CidadeId = idCidade
        //  };
        //   _service.Salvar(obj);
        //  return Json(true);
        //  }

        [HttpDelete("Remover")]
        [AllowAnonymous]
        public JsonResult Remover(Guid id)
        {
            try
            {
                _service.Remover(id);
                return Json(RetornoApi.Sucesso(true));
            }
            catch (Exception ex)
            {
                return Json(RetornoApi.Erro(ex.Message));
            }

            //_service.Remover(id);
            //  return Json(true);
        }
    }
}
