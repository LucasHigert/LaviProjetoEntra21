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
        $.ajax({
            url: "http://localhost:53131/pessoa/inserir",
            method: "post",
            data: {
                Nome: $nome,
                CPF: $cpf
            },
            success: function (data) { $("#modal-categoria").modal('hide'); $tabelaPessoa.ajax.reload() },
            error: function (err) { alert("Erro") }
        })

    })
})