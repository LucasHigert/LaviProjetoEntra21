$(function () {

    $nome = $("#campo-nome").val();

    $tabelaPaciente = $('#tabela').DataTable({
            ajax: "/atendimentoespecial/ObterPeloNome?nome="+ $nome,
            serverSide: true,
            columns: [
            {'data': 'id'},
            {'data': 'Nome'},
            {
                render: function(data,type,row){
                    return '<button class="btn btn-primary" href="/atendimentoespecial/ParteCorpoEspecial?idPaciente=' + row.Id + '">@View.Resources.Resource.EsteSouEu</button>'

                }
            }

        ]

    });
    
    $("#botao").on("click",function(){
        $tabelaPaciente.ajax.reload();
    })
    
    $("#campo-nome").on("keypress",function(evt){
        
        $tabelaPaciente.ajax.reload();
        
    });
    
    
});