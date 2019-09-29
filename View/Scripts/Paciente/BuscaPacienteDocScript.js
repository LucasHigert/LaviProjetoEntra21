$(function ($) {
    $tabelaPaciente = $('#tabelad').DataTable({
        ajax: {
            url: "/Paciente/ObterPeloAtendimento",
            data: function (d) {
                d.nome = $("#campo-nome").val()
            }
        },
        method: "GET",
        serverSide: true,
        searching: false,
        info: false,
        paging: false,
        columns: [
            { 'data': 'Atendimento' },
            {
                render: function (data, type, row) {
                    return '<a class="btn btn-info" href="/atendimentoespecial/InserirAtendimento?idPaciente=' + row.Id + '"><i class="fa fa-user"></i></a>'
                }
            }

        ]
    });
    $("#campo-nome").keypress(function (e) {
        if (e.keyCode == 13) {
            $tabelaPaciente.ajax.reload();
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
