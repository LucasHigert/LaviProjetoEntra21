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