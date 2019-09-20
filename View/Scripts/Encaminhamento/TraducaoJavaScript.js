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

    //farmácia
    $("#farmacia-encaminhar-frances").on("click", function () {
        var idioma = "fr";
        obterTraducao(idioma);
    });


    $("#farmacia-encaminhar-criolo").on("click", function () {
        var idioma = "ht";
        obterTraducao(idioma);
    });

    $("#farmaciaModal").on('show.bs.modal', function (e) {
        obterTraducao('pt');
    });
    //farmácia

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

                $("#farmacia-encaminhar").text(i18n("farmaciaEncaminhar"));
                $("#remedio-encaminhar").text(i18n("remedioEncaminhar"));
                $("#quantidade-encaminhar").text(i18n("quantidadeEncaminhar"));
                $("#dias-encaminhar").text(i18n("diasEncaminhar"));

                $("#posto-encaminhar-texto-redirecionar").text(i18n("postoEncaminharTextoRedirecionar"));
                $("#posto-endereco").text(i18n("postoEndereco"));
                $("#posto-telefone").text(i18n("postoTelefone"));
            }
        })
    }


})
