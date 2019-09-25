

function validarCampo(nome, campo) {
    texto = '';
    if (nome.trim().length == 0) {
        texto = 'Nome deve ser preenchido';
    } else if (nome.trim().length < 3) {
        texto = 'Nome deve conter no mínimo 3 caracteres';
    } else if (nome.trim().length > 20) {
        texto = 'Nome deve conter no máximo 20 caracteres';
    }

    campo.classList.remove('border-danger', 'text-danger');
    var elementos = document
        .getElementsByClassName('span-erro');

    for (var i = 0; i < elementos.length; i++) {
        var elemento = elementos[i];
        var elementoPai = elemento.parentNode;
        elementoPai.removeChild(elemento);
    }

    if (texto != '') {
        campo.classList.add('border-danger', 'text-danger');

        var spanErro = document.createElement('span');
        spanErro.innerHTML = texto;
        spanErro.classList.add('span-erro',
            'text-danger', 'font-weight-bold');



        var elementoPaiDoInput = campo.parentNode;
        elementoPaiDoInput.appendChild(spanErro);

        campo.focus();
        return false;
    }

    return true;
}

function validar() {
    var campo = document.getElementById('nome');
    var nome = campo.value;
    return validarCampo(nome, campo);
}