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
        $resultado = submete();
        if ($resultado == false) {
            var campo = document.getElementById('campo-nome');
            campo.classList.add('border-danger');
        } else {
            var campo = document.getElementById('campo-nome');
            campo.classList.remove('border-info');
            campo.classList.remove('border-danger');
            campo.classList.add('border-success');
        }
    });

    $("#campo-endereco").focusout(function () {
        $endereco = $("#campo-endereco").val();
        $resultado = submete();
        if ($resultado == false) {
            var campo = document.getElementById('campo-endereco');
            campo.classList.add('border-danger');
        } else {
            var campo = document.getElementById('campo-endereco');
            campo.classList.remove('border-info');
            campo.classList.remove('border-danger');
            campo.classList.add('border-success');
        }
    });

    $("#campo-sexo").focusout(function () {
        $endereco = $("#campo-sexo").val();
        $resultado = submete();
        if ($resultado == false) {
            var campo = document.getElementById('campo-sexo');
            campo.classList.add('border-danger');
        } else {
            var campo = document.getElementById('campo-sexo');
            campo.classList.remove('border-info');
            campo.classList.remove('border-danger');
            campo.classList.add('border-success');
        }
    });

    function submete() {
        if (document.getElementById('campo-nome').value == "" || document.getElementById('campo-nome').value.length <= 2) {
            return false;
        }
        if (document.getElementById('campo-endereco').value == "") {
            return false;
        }
        if (document.getElementById('campo-sexo').value == "") {
            return false;
        } else {
            return true;
        }

    }
});
