$(function () {

    $("#campo-prioridade").focusout(function () {
        if ($("campo-nome") != "") {
            $teste = $("#campo-prioridade").val();
            if ($teste != null) {
                document.getElementById("botao-salvar").classList.remove("disabled");
            }
        }
    });


});