$(function () {
$variavel = 0;
    
    function AtualizaTabela($nome){
    if($variavel == 0){
        
    
        $tabelaPaciente = $('#tabela').DataTable({
        ajax: "/atendimentoespecial/ObterPeloNome?nome='"+ $nome + "'",
        method: "GET",
        serverSide: true,
        columns: [
        {'data': 'Nome'},
            {
                render: function(data,type,row){
                    return '<a class="btn btn-primary" href="/atendimentoespecial/ParteCorpoEspecial?idPaciente=' + row.Id + '"><i class="fa fa-user"></i></a>'

                }
            }

        ]

  
    });
    }else{
        $tabelaPaciente.ajax.reload();
    }
}
    
    $("#botao").on("click",function(){
        AtualizaTabela($("#campo-nome").val());
    })
    
  
    
});