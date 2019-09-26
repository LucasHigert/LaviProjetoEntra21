$(function () {
    $idCorpo = 0;
    $idAtendimento = 0;
    $idPaciente = 0;
    $idSintoma = 0;
    $nivelDor = 0;

    $(".botao").on("click", function () {
        $idCorpo = $(this).data("id");
        AtualizaSintoma($idCorpo);
    })


    function AtualizaSintoma($idCorpo) {

        $sintoma = $("#sintoma").select2({
            dropdownParent: $('#modal-sintoma'),
            ajax: {
                url: "/atendimentoespecial/ObterSintomaParte?id=" + $idCorpo,
                dataType: "json"
            }

        });
    };

    var $niveldedor = 0;

    $("#pouco").click(function () {
        $niveldedor = $(this).val(1)
    });

    $("#medio").click(function () {
        $niveldedor = $(this).val(2);
    });

    $("#alto").click(function () {
        $niveldedor = $(this).val(3);
    });

    $("#botao-salvar").on("click", function () {
        $idAtendimento = $("#idAtendimento").data("id");
        $idPaciente = $("#idPaciente").data("id");
        $idSintoma = $("#sintoma").val();
        $nivelDor = $($niveldedor).val();

        if ($idSintoma == null) {
            return;
        }
        $.ajax({
            url: "/atendimentoespecial/InserirSintoma",
            method: "post",
            data: {
                idAtendimento: $idAtendimento,
                idPaciente: $idPaciente,
                nivelDor: $nivelDor,
                idSintoma: $idSintoma
            },
            success: function (data) { $("#sintoma").val(null); $("#nivelDor").val(0); $("#modal-sintoma").modal('hide'); $tabela.ajax.reload(); },
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
        searching: false,
        info: false,
        paging: false,
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