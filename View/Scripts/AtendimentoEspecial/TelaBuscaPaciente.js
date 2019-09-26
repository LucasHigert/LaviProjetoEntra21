$(function () {
    $variavel = 0;

    function AtualizaTabela($nome) {
        if ($variavel == 0) {

            $tabelaPaciente = $('#tabela').DataTable({
                ajax: "/atendimentoespecial/ObterPeloNome?nome=" + $nome,
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
        } else {
            $tabelaPaciente.ajax.reload();
        }
    }

    $("#botao").on("click", function () {

    })

    $(document).ready(function () {
        AtualizaTabela($("#campo-nome").val());
        $('#tabela').DataTable();
    });

});