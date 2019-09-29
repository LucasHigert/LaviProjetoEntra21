//$("#buscar").autocomplete({
//    source: function (request, response) {
//        $.ajax({
//            url: '@Url.Action("GetSearchValue","Paciente")',
//            dataType: "json",
//            data: { search: $("#buscar").val()
//        },
//            success: function (data) {
//                response($.map(data, function (item) {
//                    return { label: item.Nome, value: item.Nome };
//                }))
//            },
//            error: function (xhr, status, error) {
//                alert("Error");
//            }
//        });
//    }
//});