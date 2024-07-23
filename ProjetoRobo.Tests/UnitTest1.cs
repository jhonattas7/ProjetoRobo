// ProjetoRobo.Tests/RoboTests.cs
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjetoRobo.Controllers;
using ProjetoRobo.Models;
using System.Web.Http.Results;

[TestClass]
public class RoboTests
{
    [TestMethod]
    public void TestarMovimentoPulsoComCotoveloNaoContraido()
    {
        // Arrange
        var controller = new RoboController();
        var comandoPulso = new ComandoMovimento { Parte = "PulsoEsquerdo", Estado = "Rotação para 45º" };

        // Simula o estado do cotovelo como não fortemente contraído
        controller.Movimentar(new ComandoMovimento { Parte = "CotoveloEsquerdo", Estado = "Em Repouso" });

        // Act
        var result = controller.Movimentar(comandoPulso) as BadRequestErrorMessageResult;

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual("O pulso só pode ser movimentado se o cotovelo estiver fortemente contraído.", result.Message);
    }

    [TestMethod]
    public void TestarMovimentoPulsoComCotoveloContraido()
    {
        // Arrange
        var controlador = new RoboController();

        // Inicializa o estado do robô
        controlador.Movimentar(new ComandoMovimento { Parte = "CotoveloEsquerdo", Estado = "Contraído" });

        // Act
        var resultado = controlador.Movimentar(new ComandoMovimento { Parte = "PulsoEsquerdo", Estado = "Rotação para 45º" });

        // Assert
        Assert.IsNotNull(resultado, "O resultado não deve ser nulo.");
        var resultadoBadRequest = resultado as BadRequestErrorMessageResult;
        Assert.IsNotNull(resultadoBadRequest, "Deveria retornar BadRequest quando o cotovelo não está fortemente contraído.");
        Assert.AreEqual("O pulso só pode ser movimentado se o cotovelo estiver fortemente contraído.", resultadoBadRequest.Message);
    }

    [TestMethod]
    public void TestarMovimentoPulsoComCotoveloDiferente()
    {
        // Arrange
        var controller = new RoboController();
        // Simula o estado do cotovelo como levemente contraído
        controller.Movimentar(new ComandoMovimento { Parte = "CotoveloEsquerdo", Estado = "Levemente Contraído" });
        var comandoPulso = new ComandoMovimento { Parte = "PulsoEsquerdo", Estado = "Rotação para 90º" };

        // Act
        var result = controller.Movimentar(comandoPulso) as BadRequestErrorMessageResult;

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual("O pulso só pode ser movimentado se o cotovelo estiver fortemente contraído.", result.Message);
    }

    [TestMethod]
    public void TestarMovimentoRotacaoCabecaSequencial()
    {
        // Arrange
        var controller = new RoboController();
        var comando = new ComandoMovimento { Parte = "RotacaoCabeca", Estado = "Rotação 45º" };

        // Simula a rotação atual como "Em Repouso"
        controller.Movimentar(new ComandoMovimento { Parte = "RotacaoCabeca", Estado = "Em Repouso" });

        // Act
        var result = controller.Movimentar(comando) as OkNegotiatedContentResult<EstadoRobo>;

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual("Rotação 45º", result.Content.RotacaoCabeca);
    }

    [TestMethod]
    public void TestarMovimentoRotacaoCabecaNaoSequencial()
    {
        // Arrange
        var controller = new RoboController();
        // Simula a rotação atual como "Rotação -90º"
        controller.Movimentar(new ComandoMovimento { Parte = "RotacaoCabeca", Estado = "Rotação -90º" });
        var comando = new ComandoMovimento { Parte = "RotacaoCabeca", Estado = "Rotação 90º" };

        // Act
        var result = controller.Movimentar(comando) as BadRequestErrorMessageResult;

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual("A rotação da cabeça deve ser sequencial.", result.Message);
    }

    [TestMethod]
    public void TestarMovimentoInclinacaoCabecaSequencial()
    {
        // Arrange
        var controller = new RoboController();
        var comando = new ComandoMovimento { Parte = "InclinacaoCabeca", Estado = "Para Cima" };

        // Simula a inclinação atual como "Em Repouso"
        controller.Movimentar(new ComandoMovimento { Parte = "InclinacaoCabeca", Estado = "Em Repouso" });

        // Act
        var result = controller.Movimentar(comando) as OkNegotiatedContentResult<EstadoRobo>;

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual("Para Cima", result.Content.InclinacaoCabeca);
    }

    [TestMethod]
    public void TestarMovimentoInclinacaoCabecaNaoSequencial()
    {
        // Arrange
        var controller = new RoboController();
        // Simula a inclinação atual como "Para Cima"
        controller.Movimentar(new ComandoMovimento { Parte = "InclinacaoCabeca", Estado = "Para Cima" });
        var comando = new ComandoMovimento { Parte = "InclinacaoCabeca", Estado = "Para Baixo" };

        // Act
        var result = controller.Movimentar(comando) as BadRequestErrorMessageResult;

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual("A inclinação da cabeça deve ser sequencial.", result.Message);
    }

    [TestMethod]
    public void TestarMovimentoCotoveloEsquerdoSequencial()
    {
        // Arrange
        var controller = new RoboController();
        var comando = new ComandoMovimento { Parte = "CotoveloEsquerdo", Estado = "Levemente Contraído" };

        // Simula o estado atual como "Em Repouso"
        controller.Movimentar(new ComandoMovimento { Parte = "CotoveloEsquerdo", Estado = "Em Repouso" });

        // Act
        var result = controller.Movimentar(comando) as OkNegotiatedContentResult<EstadoRobo>;

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual("Levemente Contraído", result.Content.CotoveloEsquerdo);
    }

    [TestMethod]
    public void TestarMovimentoCotoveloEsquerdoNaoSequencial()
    {
        // Arrange
        var controller = new RoboController();
        var comando = new ComandoMovimento { Parte = "CotoveloEsquerdo", Estado = "Fortemente Contraído" };

        // Simula o estado atual como "Em Repouso"
        controller.Movimentar(new ComandoMovimento { Parte = "CotoveloEsquerdo", Estado = "Em Repouso" });

        // Act
        var result = controller.Movimentar(comando) as BadRequestErrorMessageResult;

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual("O movimento do cotovelo esquerdo deve ser sequencial.", result.Message);
    }

    [TestMethod]
    public void TestarMovimentoPulsoEsquerdoSemCotoveloFortementeContraido()
    {
        // Arrange
        var controller = new RoboController();
        var comando = new ComandoMovimento { Parte = "PulsoEsquerdo", Estado = "Rotação para 90º" };

        // Simula o estado do cotovelo como contraído
        controller.Movimentar(new ComandoMovimento { Parte = "CotoveloEsquerdo", Estado = "Contraído" });

        // Act
        var result = controller.Movimentar(comando) as BadRequestErrorMessageResult;

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual("O pulso só pode ser movimentado se o cotovelo estiver fortemente contraído.", result.Message);
    }

    [TestMethod]
    public void TestarMovimentoCotoveloDireitoSequencial()
    {
        // Arrange
        var controller = new RoboController();
        var comando = new ComandoMovimento { Parte = "CotoveloDireito", Estado = "Levemente Contraído" };

        // Simula o estado atual como "Em Repouso"
        controller.Movimentar(new ComandoMovimento { Parte = "CotoveloDireito", Estado = "Em Repouso" });

        // Act
        var result = controller.Movimentar(comando) as OkNegotiatedContentResult<EstadoRobo>;

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual("Levemente Contraído", result.Content.CotoveloDireito);
    }

    [TestMethod]
    public void TestarMovimentoCotoveloDireitoNaoSequencial()
    {
        // Arrange
        var controller = new RoboController();
        var comando = new ComandoMovimento { Parte = "CotoveloDireito", Estado = "Fortemente Contraído" };

        // Simula o estado atual como "Em Repouso"
        controller.Movimentar(new ComandoMovimento { Parte = "CotoveloDireito", Estado = "Em Repouso" });

        // Act
        var result = controller.Movimentar(comando) as BadRequestErrorMessageResult;

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual("O movimento do cotovelo direito deve ser sequencial.", result.Message);
    }

}
