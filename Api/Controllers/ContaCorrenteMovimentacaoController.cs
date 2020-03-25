using System;
using Aplicacao.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContaCorrenteMovimentacaoController : ControllerBase
    {
        private readonly IContaCorrenteMovimentacaoServico _contaCorrenteMovimentacaoServico;

        public ContaCorrenteMovimentacaoController(IContaCorrenteMovimentacaoServico contaCorrenteMovimentacaoServico)
        {
            _contaCorrenteMovimentacaoServico = contaCorrenteMovimentacaoServico;
        }

        [HttpGet]
        [Route("Listar")]
        public ActionResult Depositar([FromQuery] int idContaCorrente)
        {
            try
            {
                var movimentos = _contaCorrenteMovimentacaoServico.Listar(idContaCorrente);
                return Ok(new { Status = 200, Retorno = new { Mensagem = "Ok", Objeto = movimentos, ComErro = false } });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Status = 400, Retorno = new { Mensagem = ex.Message, ComErro = true } });
            }
        }
    }
}