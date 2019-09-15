$(function () {


    $("#campo-cep").on("keypress", function (evt) {
        if (evt.keyCode == 13) {
            buscarCEP();
        }
    });
    function buscarCEP() {

        $cep = $("#cep").val().replace('-', '');
        if ($cep.lenght != 8) {
            alert("Tamanho do cep invalido");
            $("#cep").focus();
            return;
        }
        $.ajax({
            url: 'https://viacep.com.br/ws/' + $cep + '/json/',
            method: 'get',
            success: function (data) {
                $localidade = data.localidade;
                $logradouro = data.logradouro;
                $unidadeFederativa = data.uf;

                $("#localidade").val($localidade);
                $("#logradouro").val($logradouro);
                $("#unidade-federativa").val($unidadeFederativa);
                $("#numero").focus();
            },
            error: function (err) {
                alert('Digita o CEP direto cara');
                $("#cep").focus();
    }








});