<%@ Page Title="Controle do R.O.B.O" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ControleRobo.aspx.cs" Inherits="ProjetoRobo.ControleRobo" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row justify-content-center">
            <!-- Coluna para Botões de Controle -->
            <div class="col-md-6 text-center"><br />

                <!-- Cabeça - Rotação e Inclinação -->
                <div class="mb-4">
                    <h4 class="mb-3">Cabeça - Inclinação</h4>
                    <button type="button" class="btn btn-primary mx-2" onclick="movimentarRobo('InclinacaoCabeca', 'Para Cima')">Para Cima</button>
                    <button type="button" class="btn btn-primary mx-2" onclick="movimentarRobo('InclinacaoCabeca', 'Em Repouso')">Em Repouso</button>
                    <button type="button" class="btn btn-primary mx-2" onclick="movimentarRobo('InclinacaoCabeca', 'Para Baixo')">Para Baixo</button>
                    <h4 class="mt-4 mb-3">Cabeça - Rotação</h4>
                    <button type="button" class="btn btn-primary mx-2" id="rotacaoMenos90" onclick="movimentarRobo('RotacaoCabeca', 'Rotação -90º')">Rotação -90º</button>
                    <button type="button" class="btn btn-primary mx-2" id="rotacaoMenos45" onclick="movimentarRobo('RotacaoCabeca', 'Rotação -45º')">Rotação -45º</button>
                    <button type="button" class="btn btn-primary mx-2" id="rotacaoRepouso" onclick="movimentarRobo('RotacaoCabeca', 'Em Repouso')">Em Repouso</button>
                    <button type="button" class="btn btn-primary mx-2" id="rotacao45" onclick="movimentarRobo('RotacaoCabeca', 'Rotação 45º')">Rotação 45º</button>
                    <button type="button" class="btn btn-primary mx-2" id="rotacao90" onclick="movimentarRobo('RotacaoCabeca', 'Rotação 90º')">Rotação 90º</button>
                </div>

                <div class="row">
                    <!-- Cotovelo Esquerdo -->
                    <div class="col-md-6 mb-4">
                        <h4 class="mb-3">Cotovelo Esquerdo</h4>
                        <button type="button" class="btn btn-primary btn-block mb-2" onclick="movimentarRobo('CotoveloEsquerdo', 'Em Repouso')">Em Repouso</button>
                        <button type="button" class="btn btn-primary btn-block mb-2" onclick="movimentarRobo('CotoveloEsquerdo', 'Levemente Contraído')">Levemente Contraído</button>
                        <button type="button" class="btn btn-primary btn-block mb-2" onclick="movimentarRobo('CotoveloEsquerdo', 'Contraído')">Contraído</button>
                        <button type="button" class="btn btn-primary btn-block mb-2" onclick="movimentarRobo('CotoveloEsquerdo', 'Fortemente Contraído')">Fortemente Contraído</button>
                    </div>
                    <!-- Cotovelo Direito -->
                    <div class="col-md-6 mb-4">
                        <h4 class="mb-3">Cotovelo Direito</h4>
                        <button type="button" class="btn btn-primary btn-block mb-2" onclick="movimentarRobo('CotoveloDireito', 'Em Repouso')">Em Repouso</button>
                        <button type="button" class="btn btn-primary btn-block mb-2" onclick="movimentarRobo('CotoveloDireito', 'Levemente Contraído')">Levemente Contraído</button>
                        <button type="button" class="btn btn-primary btn-block mb-2" onclick="movimentarRobo('CotoveloDireito', 'Contraído')">Contraído</button>
                        <button type="button" class="btn btn-primary btn-block mb-2" onclick="movimentarRobo('CotoveloDireito', 'Fortemente Contraído')">Fortemente Contraído</button>
                    </div>
                </div>

                <div class="row">
                    <!-- Pulso Esquerdo -->
                    <div class="col-md-6 mb-4">
                        <h4 class="mt-4 mb-3">Pulso Esquerdo</h4>
                        <button id="pulsoEsquerdoMenos90" type="button" disabled="disabled" class="btn btn-primary btn-block mb-2" onclick="movimentarRobo('PulsoEsquerdo', 'Rotação para -90º')">Rotação para -90º</button>
                        <button id="pulsoEsquerdoMenos45" type="button" disabled="disabled" class="btn btn-primary btn-block mb-2" onclick="movimentarRobo('PulsoEsquerdo', 'Rotação para -45º')">Rotação para -45º</button>
                        <button id="pulsoEsquerdoRepouso" type="button" disabled="disabled" class="btn btn-primary btn-block mb-2" onclick="movimentarRobo('PulsoEsquerdo', 'Em Repouso')">Em Repouso</button>
                        <button id="pulsoEsquerdo45" type="button" disabled="disabled" class="btn btn-primary btn-block mb-2" onclick="movimentarRobo('PulsoEsquerdo', 'Rotação para 45º')">Rotação para 45º</button>
                        <button id="pulsoEsquerdo90" type="button" disabled="disabled" class="btn btn-primary btn-block mb-2" onclick="movimentarRobo('PulsoEsquerdo', 'Rotação para 90º')">Rotação para 90º</button>
                        <button id="pulsoEsquerdo135" type="button" disabled="disabled" class="btn btn-primary btn-block mb-2" onclick="movimentarRobo('PulsoEsquerdo', 'Rotação para 135º')">Rotação para 135º</button>
                        <button id="pulsoEsquerdo180" type="button" disabled="disabled" class="btn btn-primary btn-block mb-2" onclick="movimentarRobo('PulsoEsquerdo', 'Rotação para 180º')">Rotação para 180º</button>
                    </div>
                    <!-- Pulso Direito -->
                    <div class="col-md-6 mb-4">
                        <h4 class="mt-4 mb-3">Pulso Direito</h4>
                        <button id="pulsoDireitoMenos90" type="button" disabled="disabled" class="btn btn-primary btn-block mb-2" onclick="movimentarRobo('PulsoDireito', 'Rotação para -90º')">Rotação para -90º</button>
                        <button id="pulsoDireitoMenos45" type="button" disabled="disabled" class="btn btn-primary btn-block mb-2" onclick="movimentarRobo('PulsoDireito', 'Rotação para -45º')">Rotação para -45º</button>
                        <button id="pulsoDireitoRepouso" type="button" disabled="disabled" class="btn btn-primary btn-block mb-2" onclick="movimentarRobo('PulsoDireito', 'Em Repouso')">Em Repouso</button>
                        <button id="pulsoDireito45" type="button" disabled="disabled" class="btn btn-primary btn-block mb-2" onclick="movimentarRobo('PulsoDireito', 'Rotação para 45º')">Rotação para 45º</button>
                        <button id="pulsoDireito90" type="button" disabled="disabled" class="btn btn-primary btn-block mb-2" onclick="movimentarRobo('PulsoDireito', 'Rotação para 90º')">Rotação para 90º</button>
                        <button id="pulsoDireito135" type="button" disabled="disabled" class="btn btn-primary btn-block mb-2" onclick="movimentarRobo('PulsoDireito', 'Rotação para 135º')">Rotação para 135º</button>
                        <button id="pulsoDireito180" type="button" disabled="disabled" class="btn btn-primary btn-block mb-2" onclick="movimentarRobo('PulsoDireito', 'Rotação para 180º')">Rotação para 180º</button>
                    </div>
                </div>

            </div>
            <!-- Coluna para Labels e Mensagens -->
            <br /><br /><br /><br /><br /><br /><br />
            <div class="container h-100">
                <div class="row h-100 justify-content-center align-items-center">
                    <div class="col-md-6 text-center">
                        <div class="mb-4">
                            <h3 class="bg-light p-3 rounded shadow mx-auto" style="display: inline-block;">Estado Atual do R.O.B.O</h3>
                        </div><br />
                        <div class="sticky-top bg-light p-2 text-center" style="top: 0; z-index: 100;">
                            <label id="estadoInclinacaoCabeca" class="d-block mb-2" style="font-size: 1.1em;">Inclinação da Cabeça: Em Repouso</label><br />
                            <label id="estadoRotacaoCabeca" class="d-block mb-2" style="font-size: 1.1em;">Rotação da Cabeça: Em Repouso</label><br />
                            <label id="estadoCotoveloEsquerdo" class="d-block mb-2" style="font-size: 1.1em;">Cotovelo Esquerdo: Em Repouso</label><br />
                            <label id="estadoPulsoEsquerdo" class="d-block mb-2" style="font-size: 1.1em;">Pulso Esquerdo: Em Repouso</label><br />
                            <label id="estadoCotoveloDireito" class="d-block mb-2" style="font-size: 1.1em;">Cotovelo Direito: Em Repouso</label><br />
                            <label id="estadoPulsoDireito" class="d-block mb-2" style="font-size: 1.1em;">Pulso Direito: Em Repouso</label><br />
                        </div>
                        <br />
                        <h3 class="mt-4">Mensagens</h3>
                        <div id="mensagemErro" style="color: red; font-size: 0.9em;"></div>
                    </div>
                </div>
            </div>

        </div>
    </div>
</asp:Content>
