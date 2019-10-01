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



});