$(function () {
    $idAlterar = -1;

    $tabelaCargo = $('#cargos-index').DataTable({
        ajax: '',
        serverSide: true,
        columns: [
            { 'data': 'Id' },
            { 'data': 'Nome' }            
            {
                render: function (data, type, row) {
                    return '<button class="btn btn-primary botao-editar" data-id="' + row.Id + '">Editar</button>\<button class="btn btn-danger botao-apagar" data-id="' + row.Id + '">Apagar</button>'

                }
            },
            alert("aqui"),

        ]
    });
});