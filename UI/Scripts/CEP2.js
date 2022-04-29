jQuery(function ($) {
   // alert("jueueueueu");
    $("input[name='tCep']").change(function () {
        var cep_code = $(this).val();
        if (cep_code.length <= 0) return;
        $.get("https://viacep.com.br/ws/" + cep_code + "/json/", function (result) {
            if (false) {
                alert(result.message || "Ops aconteceu um erro");
                return;
            }
            $("input[name='tCep']").val(result.cep);
            $("input[name='tLogradouro']").val(result.logradouro);
            $("input[name='tCidade']").val(result.localidade);
            $("input[name='tBairro']").val(result.bairro);
            $("input[name='tEstado']").val(result.uf);
        });
    });
});