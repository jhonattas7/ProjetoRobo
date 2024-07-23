using System;
using System.Web.Http;
using ProjetoRobo.Models;

namespace ProjetoRobo.Controllers
{
    [RoutePrefix("api/robo")]
    public class RoboController : ApiController
    {
        private static EstadoRobo estadoAtual = new EstadoRobo();

        [HttpPost]
        [Route("movimentar")]
        public IHttpActionResult Movimentar([FromBody] ComandoMovimento comando)
        {
            string[] estados;
            string mensagemErro;

            switch (comando.Parte)
            {
                case "RotacaoCabeca":
                    estados = new[] { "Rotação -90º", "Rotação -45º", "Em Repouso", "Rotação 45º", "Rotação 90º" };
                    mensagemErro = "A rotação da cabeça deve ser sequencial.";
                    if (estadoAtual.RotacaoCabeca != comando.Estado && !MovimentoSequencial(estadoAtual.RotacaoCabeca, comando.Estado, estados))
                    {
                        return BadRequest(mensagemErro);
                    }
                    estadoAtual.RotacaoCabeca = comando.Estado;
                    break;

                case "InclinacaoCabeca":
                    estados = new[] { "Para Cima", "Em Repouso", "Para Baixo" };
                    mensagemErro = "A inclinação da cabeça deve ser sequencial.";
                    if (estadoAtual.InclinacaoCabeca != comando.Estado && !MovimentoSequencial(estadoAtual.InclinacaoCabeca, comando.Estado, estados))
                    {
                        return BadRequest(mensagemErro);
                    }
                    estadoAtual.InclinacaoCabeca = comando.Estado;
                    break;

                case "CotoveloEsquerdo":
                    estados = new[] { "Em Repouso", "Levemente Contraído", "Contraído", "Fortemente Contraído" };
                    mensagemErro = "O movimento do cotovelo esquerdo deve ser sequencial.";
                    if (estadoAtual.CotoveloEsquerdo != comando.Estado && !MovimentoSequencial(estadoAtual.CotoveloEsquerdo, comando.Estado, estados))
                    {
                        return BadRequest(mensagemErro);
                    }
                    estadoAtual.CotoveloEsquerdo = comando.Estado;
                    break;

                case "PulsoEsquerdo":
                    if (estadoAtual.CotoveloEsquerdo != "Fortemente Contraído")
                    {
                        return BadRequest("O pulso só pode ser movimentado se o cotovelo estiver fortemente contraído.");
                    }
                    estados = new[] { "Rotação para -90º", "Rotação para -45º", "Em Repouso", "Rotação para 45º", "Rotação para 90º", "Rotação para 135º", "Rotação para 180º" };
                    mensagemErro = "O movimento do pulso esquerdo deve ser sequencial.";
                    if (estadoAtual.PulsoEsquerdo != comando.Estado && !MovimentoSequencial(estadoAtual.PulsoEsquerdo, comando.Estado, estados))
                    {
                        return BadRequest(mensagemErro);
                    }
                    estadoAtual.PulsoEsquerdo = comando.Estado;
                    break;

                case "CotoveloDireito":
                    estados = new[] { "Em Repouso", "Levemente Contraído", "Contraído", "Fortemente Contraído" };
                    mensagemErro = "O movimento do cotovelo direito deve ser sequencial.";
                    if (estadoAtual.CotoveloDireito != comando.Estado && !MovimentoSequencial(estadoAtual.CotoveloDireito, comando.Estado, estados))
                    {
                        return BadRequest(mensagemErro);
                    }
                    estadoAtual.CotoveloDireito = comando.Estado;
                    break;

                case "PulsoDireito":
                    if (estadoAtual.CotoveloDireito != "Fortemente Contraído")
                    {
                        return BadRequest("O pulso só pode ser movimentado se o cotovelo estiver fortemente contraído.");
                    }
                    estados = new[] { "Rotação para -90º", "Rotação para -45º", "Em Repouso", "Rotação para 45º", "Rotação para 90º", "Rotação para 135º", "Rotação para 180º" };
                    mensagemErro = "O movimento do pulso direito deve ser sequencial.";
                    if (estadoAtual.PulsoDireito != comando.Estado && !MovimentoSequencial(estadoAtual.PulsoDireito, comando.Estado, estados))
                    {
                        return BadRequest(mensagemErro);
                    }
                    estadoAtual.PulsoDireito = comando.Estado;
                    break;

                default:
                    return BadRequest("Parte do robô desconhecida.");
            }

            return Ok(estadoAtual);
        }

        private bool MovimentoSequencial(string estadoAtual, string novoEstado, string[] estadosValidos)
        {
            int currentIndex = Array.IndexOf(estadosValidos, estadoAtual);
            int newIndex = Array.IndexOf(estadosValidos, novoEstado);

            if (currentIndex == -1 || newIndex == -1)
            {
                return false; 
            }

            return Math.Abs(currentIndex - newIndex) <= 1;
        }
    }
}
