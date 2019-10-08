$(function () {

    $nome = "";
    $tabela = $('#tabela').DataTable({
        ajax: {
            url: "/paciente/ObterPeloNome",
            data: function (d) {
                d.nome = $nome;
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
                    return '<a id=' + row.Id + ' class="botao-selecionar btn btn-info text-white" data-dismiss="modal" data-id=' + row.Id + ' > <i class="fa fa-plus"> Selecionar</i></a > '
                }
            }

        ]
    });

    $("#documentoModal").on("click", ".botao-selecionar", function () {
        var tr = document.getElementById($(this).data("id")).parentNode.parentNode;
        var td = tr.childNodes[0].childNodes[0];

        $("#campo-id").val($(this).data("id"));
        $("#campo-nome").val(td.data);
        AtualizaTabelaAtendimento();
    })

    $("#documentoModal #campo-nome").keypress(function (e) {
        if (e.keyCode == 13) {
            AtualizaTabela();
        }
    });


    function AtualizaTabela() {
        $nome = $("#documentoModal #campo-nome").val();
        $tabela.ajax.reload();
    };

     $controle = 0;
    function AtualizaTabelaAtendimento() {
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
                        return '<a class="botao-atendimento btn btn-info"  href="/atendimento/pacienteDocumentos?id=' + row.Id + '"\   data-id="' + row.Id + '"\
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

});