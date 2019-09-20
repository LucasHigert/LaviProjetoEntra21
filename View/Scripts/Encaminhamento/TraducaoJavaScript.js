$(function () {


    $("#posto-encaminhar-frances").on("click", function () {
        var idioma = "fr";
        obterTraducao(idioma);
    });


    $("#posto-encaminhar-criolo").on("click", function () {
        var idioma = "ht";
        obterTraducao(idioma);
    });

    $("#postoModal").on('show.bs.modal', function (e) {
        obterTraducao('pt');
    });

    function obterTraducao(idioma) {
        $.ajax({
            url: "/language/index?idioma=" + idioma,
            method: "get",
            success: function (data) {
                //  Parse it
                data = JSON.parse(data);
                //  Set the data
                i18n.translator.add(data);
                //  Translate away

                $("#posto-encaminhar-texto-redirecionar").text(i18n("postoEncaminharTextoRedirecionar"));
                $("#posto-encaminhar-telefone").text(i18n("postoEncaminharTelefone"));

            }
        })
    }


})
