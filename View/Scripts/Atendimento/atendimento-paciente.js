$(function ($) {

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
                    return '<a id="' + row.Id + '" class="selecionar btn btn-success text-white" data-dismiss="modal" \
                    data-id="' + row.Id + '"\
                    data-nome="' + row.Nome + '"> <i class="fa fa-check"></i></a > '
                }
            }

        ]
    });

    $("#tabela").on("click", ".selecionar", function () {
        //var tr = document.getElementById($(this).Id);
        //var td = tr.
        $id = $(this).data("id");
        $nome = $(this).data("nome");
        
        $("#campo-paciente-id").val($id);
        $("#campo-paciente").val($nome);

    });

    $("#botao-salvar-modal").on("click", function () {
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


    $("#campo-pesquisa").keypress(function (e) {
        if (e.keyCode == 13) {
            AtualizaTabela();
        }
    });

    $("#botao-pesquisar").on("click", function () {
        alert("ola");
        AtualizaTabela();
    });

    function AtualizaTabela() {
        $tabela.ajax.reload();
    }


});