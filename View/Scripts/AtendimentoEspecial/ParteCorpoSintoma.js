$(function () {
    $idCorpo = 0;
    $(".botao").on("click", function () {
        $idCorpo = $(this).data("id");
        $("#sintoma").select2({
            dropdownParent: $('#modal-sintoma'),
            ajax: {
                url: "/atendimentoespecial/ObterSintomaParte?id=" + $idCorpo,
                dataType: "json"
            }

        })

    });

    $("#botao-salvar").on("click", function () {
        

    })
})