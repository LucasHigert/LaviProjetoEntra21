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

    //hospital
    $("#hospital-encaminhar-frances").on("click", function () {
        var idioma = "fr";
        obterTraducao(idioma);
    });


    $("#hospital-encaminhar-criolo").on("click", function () {
        var idioma = "ht";
        obterTraducao(idioma);
    });

    $("#hospitalModal").on('show.bs.modal', function (e) {
        obterTraducao('pt');
    });
    //hospital
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

                $("#encaminhamento-posto").text(i18n("encaminhamentoPosto"));
                $("#encaminhamento-hospital").text(i18n("encaminhamentoHospital"));
                $("#encaminhamento-farmacia").text(i18n("encaminhamentoFarmacia"));

                $("#farmacia-encaminhar").text(i18n("farmaciaEncaminhar"));
                $("#remedio-encaminhar").text(i18n("remedioEncaminhar"));
                $("#quantidade-encaminhar").text(i18n("quantidadeEncaminhar"));
                $("#dias-encaminhar").text(i18n("diasEncaminhar"));

                $("#posto-encaminhar-texto-redirecionar").text(i18n("postoEncaminharTextoRedirecionar"));
                $("#posto-endereco").text(i18n("postoEndereco"));
                $("#posto-telefone").text(i18n("postoTelefone"));

                $("#hospital-encaminhar-texto-redirecionar").text(i18n("hospitalEncaminharTextoRedirecionar"));
                $("#hospital-fim").text(i18n("hospitalFim"));
                $("#hospital-endereco").text(i18n("hospitalEndereco"));
                $("#hospital-nome").text(i18n("hospitalNome"));
            }
        })
    }


})
