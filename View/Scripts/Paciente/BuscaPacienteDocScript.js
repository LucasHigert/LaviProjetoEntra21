$(function () {

    $controle = 0;
    function AtualizaTabela() {
        if ($controle == 0) {
            $tabelaAtendimento = $('#tabelaAtendimento').DataTable({
                ajax: {
                    url: "/paciente/ObterPeloPaciente",
                    data: function (d) {
                        d.id = $("#campo-id").val()
                    }
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
            $controle = 1;
        } else {
            $tabelaAtendimento.ajax.reload();
        }
    }

    //Botao pesquisar
    $("#botao").on("click", function () {
        $idPaciente = $("#campo-id").val();
        AtualizaTabela();
    });


    $("#documentoFormularioModal").on('shown.bs.modal', function () {
        $("#campo-idAtendimento").val($idPaciente)
        $('#tabelaSintomas').DataTable({
            ajax: {
                url: "/atendimentoespecial/ObterSintomaAtendimento?idAtendimento=" + $idPaciente,
            },
            method: "GET",
            serverSide: true,
            searching: false,
            info: false,
            paging: false,
            columns: [
                {
                    "data": "sintoma",
                    "data": "intensidade"
                }
            ]
        });
    });

    $("#tabelaAtendimento").on("click", ".botao-atendimento", function () {
        $('#documentoFormularioModal').modal('show');
        $idPaciente = $("#id").val(this);
    })
});
