$(function () {

    $idPaciente = 0;
    
    $("#campo-nome").keypress(function (e) {
        if (e.keyCode == 13) {
            AtualizaTabela();
        }
    });

    $("#pesquisar").on("click", function () {
        AtualizaTabela();
    });

    function AtualizaTabela() {
        $tabelaPaciente = $('#tabelaAtendimento').DataTable({
            ajax: {
                url: "/paciente/ObterPeloPaciente?id=" + $idPaciente,
            },
            method: "GET",
            serverSide: true,
            searching: false,
            info: false,
            paging: false,
            columns: [
                { 'data': 'DataAtendimento' },
                { 'data': 'depois tem q mudar' },
                {
                    render: function (data, type, row) {
                        return '<a class="btn btn-info" href="/atendimentoespecial/InserirAtendimento?idPaciente=' + row.Id + '"><i class="fa fa-user"></i></a>'
                    }
                }

            ]
        });    }
    $("#botao").on("click", function () {
        $idPaciente = $("#campo-id").val();
        AtualizaTabela();
    })
}); 
