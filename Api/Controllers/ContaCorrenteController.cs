using System;
using Aplicacao.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContaCorrenteController : ControllerBase
    {
        private readonly IContaCorrenteServico _contaCorrenteServico;

        public ContaCorrenteController(IContaCorrenteServico contaCorrenteServico)
        {
            _contaCorrenteServico = contaCorrenteServico;
        }

        [HttpPut]
        [Route("Depositar/{valor}")]
        public ActionResult Depositar(decimal valor)
        {
            try
            {
                _contaCorrenteServico.Depositar(valor);
                return Ok(new { Status = 200, Retorno = new { Mensagem = "Ok", ComErro = false } });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Status = 400, Retorno = new { Mensagem = ex.Message, ComErro = true } });
            }
        }

        [HttpPut]
        [Route("Pagar/{valor}")]
        public ActionResult Pagar(decimal valor)
        {
            try
            {
                _contaCorrenteServico.Pagar(valor);
                return Ok(new { Status = 200, Retorno = new { Mensagem = "Ok", ComErro = false } });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Status = 400, Retorno = new { Mensagem = ex.Message, ComErro = true } });
            }
        }

        [HttpPut]
        [Route("Retirar/{valor}")]
        public ActionResult Retirar(decimal valor)
        {
            try
            {
                _contaCorrenteServico.Retirar(valor);
                return Ok(new { Status = 200, Retorno = new { Mensagem = "Ok", ComErro = false } });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Status = 400, Retorno = new { Mensagem = ex.Message, ComErro = true } });
            }
        }
    }
}