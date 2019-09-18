$(function () {
    $(".details").click(function () {
        var id = $(this).attr("data-id");
        $("#modal").load("Details?id=" + id, function () {
            $("#modal").modal();
        })
    });
})




