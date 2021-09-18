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
    public class CidadeController : Controller
    {
        private ICidadeService _service;

        public CidadeController(ICidadeService service)
        {
            _service = service;
        }

        [HttpGet("ListaCidades")]
        [AllowAnonymous]
        public JsonResult ListaCidades()
        {
            try
            {
                var obj =_service.listaCidades();
                return Json(RetornoApi.Sucesso(obj));
            }
            catch(Exception ex)
            {
                return Json(RetornoApi.Erro(ex.Message));
            }
            
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
           // return Json(_service.BuscaPorId(id));
        }
        [HttpPost("Salvar")]
        [AllowAnonymous]
        public JsonResult Salvar(string nome, string cep, string uf)
        {
            try
            {
                var obj = new Cidade
                {
                    Nome = nome,
                    CEP = cep,
                    UF = uf
                };
                _service.Salvar(obj);
                return Json(RetornoApi.Sucesso(obj));
            }
            catch (Exception ex)
            {
                return Json(RetornoApi.Erro(ex.Message));
            }
          //  var obj = new Cidade
          //  {
          //      Nome = nome,
            //    CEP = cep,
            //    UF = uf
          //  };
          //  _service.Salvar(obj);
           // return Json(true);
        }

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
           // _service.Remover(id);
          //  return Json(true);
        }
    }
}
