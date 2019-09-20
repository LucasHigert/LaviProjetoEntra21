$(function () {

    $("#campo-cep").focusout(function() {
        
            buscarCEP();
        
    });
    function buscarCEP() {

        $cep = $("#campo-cep").val().replace('-', '');
      
        $.ajax({
            url: 'https://viacep.com.br/ws/' + $cep + '/json/',
            method: 'get',
            success: function (data) {
                $logradouro = data.logradouro;
              

                $("#campo-endereco").val($logradouro);
               
            },
            error: function (err) {
        }

        });
    }
});