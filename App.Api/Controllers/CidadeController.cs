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
    public class CidadeController : Controller
    {
        private ICidadeService _service;

        public CidadeController(ICidadeService service)
        {
            _service = service;
        }

        [HttpGet("ListarCidades")]
        public JsonResult Listacidades()
        {
            return Json(_service.listaCidades());
        }
        [HttpGet("BuscarPorId")]
        public JsonResult BuscarPorId(Guid id)
        {
            return Json(_service.BuscaPorId(id));
        }
        [HttpPost("Salvar")]
        public JsonResult Salvar(string nome, string cep, string uf)
        {
            var obj = new Cidade
            {
                Nome = nome,
                Cep = cep,
                Uf = uf,
            };
            _service.Salvar(obj);
            return Json(true);
        }
        [HttpPost("Delete")]
        public JsonResult Remover(Guid id)
        {
            _service.Remover(id);
            return Json(true);
        }
    }
}
