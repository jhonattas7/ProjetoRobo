function movimentarRobo(parte, estado) {

    document.getElementById('mensagemErro').innerText = '';

    const comando = {
        Parte: parte,
        Estado: estado
    };

    fetch('/api/robo/movimentar', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(comando)
    })
        .then(response => {
            if (!response.ok) {
                return response.text().then(text => {
                    document.getElementById('mensagemErro').innerText = `Ocorreu um erro ao processar sua solicitação. ${text}`;
                    alert(`Ocorreu um erro ao processar sua solicitação. ${text}`);
                });
            }
            return response.json();
        })
        .then(data => {
            if (data) {
                document.getElementById('estadoCotoveloEsquerdo').innerText = `Cotovelo Esquerdo: ${data.CotoveloEsquerdo}`;
                document.getElementById('estadoPulsoEsquerdo').innerText = `Pulso Esquerdo: ${data.PulsoEsquerdo}`;
                document.getElementById('estadoCotoveloDireito').innerText = `Cotovelo Direito: ${data.CotoveloDireito}`;
                document.getElementById('estadoPulsoDireito').innerText = `Pulso Direito: ${data.PulsoDireito}`;
                document.getElementById('estadoRotacaoCabeca').innerText = `Rotação da Cabeça: ${data.RotacaoCabeca}`;
                document.getElementById('estadoInclinacaoCabeca').innerText = `Inclinação da Cabeça: ${data.InclinacaoCabeca}`;

                // Desabilita rotação da cabeça 
                if (data.InclinacaoCabeca === 'Para Baixo') {
                    document.getElementById('rotacaoMenos90').disabled = true;
                    document.getElementById('rotacaoMenos45').disabled = true;
                    document.getElementById('rotacaoRepouso').disabled = true;
                    document.getElementById('rotacao45').disabled = true;
                    document.getElementById('rotacao90').disabled = true;
                } else {
                    document.getElementById('rotacaoMenos90').disabled = false;
                    document.getElementById('rotacaoMenos45').disabled = false;
                    document.getElementById('rotacaoRepouso').disabled = false;
                    document.getElementById('rotacao45').disabled = false;
                    document.getElementById('rotacao90').disabled = false;
                }

                // Habilita botões de pulso esquerdo
                if (data.CotoveloEsquerdo === 'Fortemente Contraído') {
                    document.getElementById('pulsoEsquerdoMenos90').disabled = false;
                    document.getElementById('pulsoEsquerdoMenos45').disabled = false;
                    document.getElementById('pulsoEsquerdoRepouso').disabled = false;
                    document.getElementById('pulsoEsquerdo45').disabled = false;
                    document.getElementById('pulsoEsquerdo90').disabled = false;
                    document.getElementById('pulsoEsquerdo135').disabled = false;
                    document.getElementById('pulsoEsquerdo180').disabled = false;
                } else {
                    document.getElementById('pulsoEsquerdoMenos90').disabled = true;
                    document.getElementById('pulsoEsquerdoMenos45').disabled = true;
                    document.getElementById('pulsoEsquerdoRepouso').disabled = true;
                    document.getElementById('pulsoEsquerdo45').disabled = true;
                    document.getElementById('pulsoEsquerdo90').disabled = true;
                    document.getElementById('pulsoEsquerdo135').disabled = true;
                    document.getElementById('pulsoEsquerdo180').disabled = true;
                }

                // Habulita botões de pulso direito
                if (data.CotoveloDireito === 'Fortemente Contraído') {
                    document.getElementById('pulsoDireitoMenos90').disabled = false;
                    document.getElementById('pulsoDireitoMenos45').disabled = false;
                    document.getElementById('pulsoDireitoRepouso').disabled = false;
                    document.getElementById('pulsoDireito45').disabled = false;
                    document.getElementById('pulsoDireito90').disabled = false;
                    document.getElementById('pulsoDireito135').disabled = false;
                    document.getElementById('pulsoDireito180').disabled = false;
                } else {
                    document.getElementById('pulsoDireitoMenos90').disabled = true;
                    document.getElementById('pulsoDireitoMenos45').disabled = true;
                    document.getElementById('pulsoDireitoRepouso').disabled = true;
                    document.getElementById('pulsoDireito45').disabled = true;
                    document.getElementById('pulsoDireito90').disabled = true;
                    document.getElementById('pulsoDireito135').disabled = true;
                    document.getElementById('pulsoDireito180').disabled = true;
                }
            }
        })
        .catch(error => {
            document.getElementById('mensagemErro').innerText = `Ocorreu um erro ao processar sua solicitação. ${error}`;
            alert(`Ocorreu um erro ao processar sua solicitação. ${error}`);
        });
}
