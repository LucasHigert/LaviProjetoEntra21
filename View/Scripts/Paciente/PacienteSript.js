$(function () {
$("#botao-salvar").on("click",function(){
    //#region Setando as variaveis
    $nome = $("#campo-nome").val();
    $sexo = $("#campo-sexo").val();
    $RNE = $("#campo-rne").val();
    $cep =  $("#campo-cep").val();
    $endereco =  $("#campo-endereco").val();
    $idade =  $("#campo-idade").val();
    $telefone =  $("#campo-telefone").val();
    $passaporte =  $("#campo-passaporte").val();
    $CPF =  $("#campo-cpf").val();
    $pressao =  $("#campo-pressao").val();
    $peso =  $("#campo-peso").val();
    $altura =  $("#campo-altura").val();
    $temperatura =  $("#campo-temperatura").val();
    //#endregion
$.ajax({
    url: "/paciente/inserir",
    method: "post",
    data: {
        nome: $nome,
    sexo: $sexo ,
    rne: $RNE ,
    cep: $cep,
    endereco: $endereco,
    idade: $idade ,
    telefone: $telefone,
    passaporte: $passaporte,
    cpf: $CPF ,
    pressao: $pressao,
    peso: $peso ,
    altura: $altura,
    temperatura: $temperatura ,
},
    error: function(){
        alert("Ocorreu um erro ao adicionar, tente novamente ou contate o suporte")
    }
})
} )


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
                alert('Digita o CEP direto cara');
                $("#campo-cep").focus();
        }

        });
    }
});