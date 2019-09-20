﻿$(function () {
    $idCorpo = 0
    $idAtendimento = 0
    $idPaciente =  0
    $idSintoma = 0

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
        $idAtendimento = $("#idAtendimento").data("id");
        $idPaciente = $("#idPaciente").data("id");
        $idSintoma = $("#sintoma").val();
        $.ajax({
            url: "/atendimentoespecial/InserirSintoma",
            method: "post",
            data: {
                idAtendimento: $idAtendimento,
                nivelDor: $idPaciente,
                idSintoma: $idSintoma
            },
            success: function (data) { $("#modal-sintoma").modal('hide'); $tabela.ajax.reload(); },
            error: function (err) { alert("Não foi possivel inserir, por favor entre em contato com o suporte") }
        })

    });

    $("#tabela-sintoma").on("click", ".botao-apagar", function () {
        $idApagar = $(this).data("id");
        $.ajax({
            url: "/atendimentoespecial/apagar",
            method: "post",
            data: {
                idSintoma: $idApagar,
                idAtendimento: $idAtendimento
            },
            success: function (data) { $tabela.ajax.reload() },
            error: function (err) { alert("Erro ao apagar") }
        });
    });

    $tabela = $("#tabela-sintoma").DataTable({
        ajax: "/atendimentoespecial/obtersintomaatendimento?idAtendimento=" + $("#idAtendimento").data("id"),
        serverSide: true,
        columns: [
            { "data": "Nome" },
            {
                render: function (data, type, row) {
                    return "<button class='botao-apagar btn btn-primary' data-id='" + row.id + "' ><i class='fa fa-trash'></i></button>";
                }
            }
        ]
    });
})