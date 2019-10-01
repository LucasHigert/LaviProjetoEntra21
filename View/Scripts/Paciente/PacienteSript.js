$(function () {

    //Função que irá receber o campo e se este esta preenchido corretamente
    // e entao mudar a cor da borda
    function Cor($campo, $bool) {

        if ($bool == false) {
            var campo = document.getElementById($campo);
            campo.classList.remove("border-success");
            campo.classList.add('border-danger');
        } else {
            var campo = document.getElementById($campo);
            campo.classList.remove('border-info');
            campo.classList.remove('border-danger');
            campo.classList.add('border-success');
        }
        VerificaParaSalvar();
    }

    function VerificaParaSalvar() {
        $nome = document.getElementById("campo-nome").classList.contains("border-success");
        $sexo = document.getElementById("campo-sexo").classList.contains('border-success');
        $lingua = document.getElementById("campo-lingua").classList.contains('border-success');
        $idade = document.getElementById("campo-idade").classList.contains('border-success');

        $pressao = document.getElementById("campo-pressao").classList.contains("border-danger");
        $peso = document.getElementById("campo-peso").classList.contains("border-danger");
        $altura = document.getElementById("campo-altura").classList.contains("border-danger");
        $temperatura = document.getElementById("campo-temperatura").classList.contains("border-danger");

        $rne = document.getElementById("campo-rne").classList.contains("border-danger");
        $cep = document.getElementById("campo-cep").classList.contains("border-danger");
        $telefone = document.getElementById("campo-telefone").classList.contains("border-danger");
        $passaporte = document.getElementById("campo-passaporte").classList.contains("border-danger");


        $botao = document.getElementById("botao-salvar");

        if (($nome) && ($sexo) && ($lingua) && ($idade) &&
            ($pressao == false) && ($peso == false) && ($altura == false) && ($temperatura == false) &&
            ($rne == false) && ($cep == false) && ($telefone == false) && ($passaporte == false)) {
            $botao.classList.remove("disabled");
        } else {
            $botao.classList.add("disabled");
        }

    };

    //#region Cep
    $("#campo-cep").focusout(function () {

        var retorno = buscarCEP();
        Cor("campo-cep", retorno);

    });

    function buscarCEP() {

        $cep = $("#campo-cep").val().replace('-', '');

        $.ajax({
            url: 'https://viacep.com.br/ws/' + $cep + '/json/',
            method: 'get',
            success: function (data) {
                $logradouro = data.logradouro;


                $("#campo-endereco").val($logradouro);
                Cor("campo-endereco",true);
                return true; 
            },
            error: function (err) { Cor("campo-cep",false); Cor("campo-endereco", false); return false; }

        });
    }

    //#endregion

    //#region CPF
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

    //#endregion

    //#region Validação Campos Obrigatorios
    $("#campo-nome").focusout(function () {
        $campo = $("#campo-nome").val();
        if ($campo.length >= 3) {
            $resultado = true;
        } else {
            $resultado = false;
        }
        Cor("campo-nome", $resultado);
        VerificaParaSalvar();
    });

    $("#campo-sexo").focusout(function () {
        $campo = $("#campo-sexo").val();
        if ($campo != "0") {
            $resultado = true;
        } else {
            $resultado = false;
        }
        Cor("campo-sexo", $resultado);
    });

    $("#campo-lingua").focusout(function () {
        $campo = $("#campo-lingua").val();
        if ($campo != "0") {
            $resultado = true;
        } else {
            $resultado = false;
        }
        Cor("campo-lingua", $resultado);
    });

    $("#campo-idade").focusout(function () {
        $campo = $("#campo-idade").val();
        if ($campo == "") {
            $resultado = false;
        } else if ($campo == "0") {
            $resultado = false;
        }
        else {
            $resultado = true;
        }

        Cor("campo-idade", $resultado);
        VerificaParaSalvar();
    });

    //#endregion

    //#region Validações outros campos
    $("#campo-pressao").focusout(function () {
        $nome = $("#campo-pressao").val();
        if ($nome.length == 6) {
            $resultado = true;
        } else {
            $resultado = false;
        }
        Cor("campo-pressao", $resultado);
    });


    $("#campo-peso").focusout(function () {
        $nome = $("#campo-peso").val();
        if ($nome > 7) {
            $resultado = true;
        } else {
            $resultado = false;
        }
        Cor("campo-peso", $resultado);
    });

    $("#campo-altura").focusout(function () {
        $nome = $("#campo-altura").val();
        if ($nome.length >= 4) {
            $resultado = true;
        } else {
            $resultado = false;
        }
        Cor("campo-altura", $resultado);
    });

    $("#campo-temperatura").focusout(function () {
        $nome = $("#campo-temperatura").val();
        if ($nome.length >= 4) {
            $resultado = true;
        } else {
            $resultado = false;
        }
        Cor("campo-temperatura", $resultado);
    });

    $("#campo-rne").focusout(function () {
        $campo = $("#campo-rne").val();
        if ($campo.length <= 9) {
            $resultado = false;
        } else {
            $resultado = true;
        }
        Cor("campo-rne", $resultado);
    });

    $("#campo-telefone").focusout(function () {
        $campo = $("#campo-telefone").val();
        if ($campo.length < 14) {
            $resultado = false;
        } else {
            $resultado = true;
        }
        Cor("campo-telefone", $resultado);
    });

    $("#campo-passaporte").focusout(function () {
        $campo = $("#campo-telefone").val();
        if ($campo.length < 8) {
            $resultado = false;
        } else {
            $resultado = true;
        }
        Cor("campo-passaporte", $resultado);
    });
    //#endregion
});