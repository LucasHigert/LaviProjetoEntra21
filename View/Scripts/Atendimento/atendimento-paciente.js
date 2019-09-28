$(function () {

    $("#botao-salvar").on("click", function () {
        $nome = $("#campo-nome").val();
        $sexo = $("#campo-sexo").val();
        $idade = $("#campo-idade").val();

        $.ajax({
            url: "/paciente/inserir",
            method: "post",
            data: {
                nome: $nome,
                sexo: $sexo,
                idade: $idade
            },
            success: function (data) { $("#modal-paciente").modal('hide'); $("#campo-paciente").val($nome); },
            erro: function (err) { alert("Nao foi possivel inserir"); $("#modal-paciente").modal("hide"); }
        })

    });

    $tabela = $('#tabela').DataTable({
        ajax: {
            url: "/paciente/ObterPeloNome",
            data: function (d) {
                d.nome = $("#campo-pesquisa").val()
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
                    return '<a class="botao-selecionar btn btn-info" data-dismiss="modal" data-id=' + row.Id + '"><i class="fa fa-plus"></i></a>'
                }
            }

        ]
    });

    $("#campo-pesquisa").keypress(function (e) {
        if (e.keyCode == 13) {
            AtualizaTabela();
        }
    });

    function AtualizaTabela() {
        $tabela.ajax.reload();
    }


});