function limpa_formulário_cep() {
    //Limpa valores do formulário de cep.
    document.getElementById('cCep').value = ("");
    document.getElementById('cLogradouro').value = ("");
    document.getElementById('cCidade').value = ("");
    document.getElementById('cBairro').value = ("");
    document.getElementById('cEstado').value = ("");
}

function meu_callback(conteudo) {
    if (!("erro" in conteudo)) {
        document.getElementById('cLogradouro').value = (conteudo.logradouro);
        document.getElementById('cCidade').value = (conteudo.localidade);
        document.getElementById('cBairro').value = (conteudo.district);
        document.getElementById('cEstado').value = (conteudo.uf);
    } //end if.
    else {
        //CEP não Encontrado.
        limpa_formulário_cep();
        alert("CEP não encontrado.");
    }
}

function pesquisacep(valor) {

    //Nova variável "cep" somente com dígitos.
    var cep = valor.replace(/\D/g, '');

    //Verifica se campo cep possui valor informado.
    if (cep != "") {

        //Expressão regular para validar o CEP.
        var validacep = /^[0-9]{8}$/;

        //Valida o formato do CEP.
        if (validacep.test(cep)) {
            document.getElementById('cLogradouro').value = "...";
            document.getElementById('cCidade').value = "...";
            document.getElementById('cBairro').value = "...";
            document.getElementById('cEstado').value = "...";

            //Cria um elemento javascript.
            var script = document.createElement('script');

            //Sincroniza com o callback.
            script.src = 'https://viacep.com.br/ws/' + cep + '/json/?callback=meu_callback';

            //Insere script no documento e carrega o conteúdo.
            document.body.appendChild(script);

        } //end if.
        else {
            //cep é inválido.
            limpa_formulário_cep();
            alert("Formato de CEP inválido.");
        }
    } //end if.
    else {
        //cep sem valor, limpa formulário.
        limpa_formulário_cep();
    }
}



