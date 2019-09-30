$(function () {

    $("#campo-cep").focusout(function () {

        buscarCEP();

    });
    function buscarCEP() {

        $cep = $("#campo-cep").val().replace('-', '');

        $.ajax({
            url: 'https://viacep.com.br/ws/' + $cep + '/json/',
            method: 'get',
            success: function (data) {
                $logradouro = data.logradouro;


                $("#campo-endereco").val($logradouro);

            },
            error: function (err) {
            }

        });
    }
});

$(function () {
    $("#campo-cpf").focusout(function () {
        $cpf = $("#campo-cpf").val();
        $resultado = validaCPF($cpf);
        if ($resultado == false) {
            var campo = document.getElementById('campo-cpf');
            campo.classList.add('border-danger');

        } else {
            var campo = document.getElementById('campo-cpf');
            campo.classList.remove('border-info');
            campo.classList.remove('border-danger');
            campo.classList.add('border-success');
        }

    });
    function validaCPF(cpf) {
        var numeros, digitos, soma, i, resultado, digitos_iguais;
        digitos_iguais = 1;
        if (cpf.length < 11)
            return false;
        for (i = 0; i < cpf.length - 1; i++)
            if (cpf.charAt(i) != cpf.charAt(i + 1)) {
                digitos_iguais = 0;
                break;
            }
        if (!digitos_iguais) {
            numeros = cpf.substring(0, 9);
            digitos = cpf.substring(9);
            soma = 0;
            for (i = 10; i > 1; i--)
                soma += numeros.charAt(10 - i) * i;
            resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
            if (resultado != digitos.charAt(0))
                return false;
            numeros = cpf.substring(0, 10);
            soma = 0;
            for (i = 11; i > 1; i--)
                soma += numeros.charAt(11 - i) * i;
            resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
            if (resultado != digitos.charAt(1))
                return false;
            return true;
        }
        else
            return false;
    }
});

$(function () {

    $("#campo-nome").focusout(function () {
        $nome = $("#campo-nome").val();
        if ($nome.length >= 3) {
            $resultado = true;
        } else {
            $resultado = false;
        }
        Cor("campo-nome", $resultado);
    });

    $("#campo-sexo").focusout(function () {
        $nome = $("#campo-sexo").val();
        if ($nome != "0") {
            $resultado = true;
        } else {
            $resultado = false;
        }
        Cor("campo-sexo", $resultado);
    });

    $("#campo-idade").focusout(function () {
        $nome = $("#campo-idade").val();
        if ($nome != "") {
            $resultado = true;
        } else {
            $resultado = false;
        }
        Cor("campo-idade", $resultado);
    });

    function Cor($campo, $bool) {

        if ($bool == false) {
            var campo = document.getElementById($campo);
            campo.classList.add('border-danger');
        } else {
            var campo = document.getElementById($campo);
            campo.classList.remove('border-info');
            campo.classList.remove('border-danger');
            campo.classList.add('border-success');
        }

    }
});
