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
                {
                    render: function (data, type, row) {
                        return moment(row).format("DD/MM/YYYY")
                    }
                },
                {
                    render: function (data, type, row) {
                        return '<a class="botao-atendimento btn btn-info" id=' + row.Id + '"\   data-id="' + row.Id + '"\
                    data-nome="' + row.Nome + '"><i class="fa fa-user"></i></a>'
                    }
                }
            ]
        });
    }

    $("#tabelaAtendimento").on("click", ".botao-atendimento", function () {
        $('#documentoFormularioModal').modal('show');
        $id = $(this).data("id");
        $nome = $(this).data("nome");

        $("#campo-cidade").val($id);
        $("#campo-posto").val($nome);


    })
    $("#botao").on("click", function () {
        $idPaciente = $("#campo-id").val();
        AtualizaTabela();
    })
}); 
