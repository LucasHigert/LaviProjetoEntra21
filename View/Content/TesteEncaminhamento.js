document.getElementById("btnPrint").onclick = function () {
    printElement(document.getElementById("printThis"));
}

document.getElementById("btnPrint2").onclick = function () {
    printElement(document.getElementById("printThis2"));
}

document.getElementById("btnPrint3").onclick = function () {
    printElement(document.getElementById("printThis3"));
}
function printElement(elem) {
    var domClone = elem.cloneNode(true);

    var $printSection = document.getElementById("printSection");

    if (!$printSection) {
        var $printSection = document.createElement("div");
        $printSection.id = "printSection";
        document.body.appendChild($printSection);
    }

    $printSection.innerHTML = "";
    $printSection.appendChild(domClone);
    window.print();
}

function duplicarCampos() {
    var clone = document.getElementById('origem').cloneNode(true);
    var destino = document.getElementById('destino');
    destino.appendChild(clone);

    var camposClonados = clone.getElementsByTagName('input');

    for (i = 0; i < camposClonados.length; i++) {
        camposClonados[i].value = '';
    }
}

function removerCampos(id) {
    var node1 = document.getElementById('destino');
    node1.removeChild(node1.childNodes[0]);
}

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
            }
        })
    }


})

//farmácia
$(function () {


    $("#farmacia-encaminhar-frances").on("click", function () {
        var idioma = "fr";
        obterTraducao(idioma);
    });


    $("#farmacia-encaminhar-criolo").on("click", function () {
        var idioma = "pt";
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

                $("#farmacia-encaminhar-texto-redirecionar").text(i18n("farmaciaEncaminharTextoRedirecionar"));
            }
        })
    }


})
//fimFarmácia