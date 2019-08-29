$(function () {
    $idAlterar = -1;

    $tabelaCidade = $('#cidades-index').DataTable({
        ajax: 'http://localhost:49590/Cidade/obtertodos',
        serverSide: true,
        columns: [
            { 'data': 'Id' },
            { 'data': 'Nome' },
            { 'data': 'Estado' },
            {
                render: function (data, type, row) {
                    return '<button class="btn btn-primary botao-editar" data-id="' + row.Id + '">Editar</button>\<button class="btn btn-danger botao-apagar" data-id="' + row.Id + '">Apagar</button>'

                }
            },
            alert("aqui"),

        ]
    });
});