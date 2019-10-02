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
    var node1 = document.getElementById('destino').lastChild;
    node1.classList.add("mt-4");
}

function removerCampos(id) {
    var node1 = document.getElementById('destino');
    node1.removeChild(node1.lastChild);
}
 
