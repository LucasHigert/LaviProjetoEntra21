$(function () {

    $tabelaPaciente = $('#tabela').DataTable({
        ajax: {
            url: "/atendimentoespecial/ObterPeloNome",
            data: function (d) {
                d.nome= $("#campo-nome").val()
            }
        },
        method: "GET",
        serverSide: true,
        searching: false,
        info: false,
        paging: false,
        columns: [
            { 'data': 'Nome' },
            {
                render: function (data, type, row) {
                    return '<a class="btn btn-info" href="/atendimentoespecial/InserirAtendimento?idPaciente=' + row.Id + '"><i class="fa fa-user"></i></a>'
                }
            }

        ]
    });

    $("#campo-nome").keypress(function (e) {
        if (e.keyCode == 13) {
            AtualizaTabela();
        }
    });

    function AtualizaTabela() {
        $tabelaPaciente.ajax.reload();
    }

    $("#botao").on("click", function () {
        AtualizaTabela();
    })

});