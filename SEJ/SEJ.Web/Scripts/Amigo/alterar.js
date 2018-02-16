$(document).ready(function () {

    $('#btnSalvar').on('click', function () {

        var amigo = {};

        amigo.Nome = $('#txtNome').val();
        amigo.Endereco = $('#txtEndereco').val();
        amigo.Idade = $('#txtIdade').val();
        amigo.Bairro = $('#txtBairro').val();
        amigo.Numero = $('#txtNumero').val();

        if (amigo.Nome != '') {
            $.ajax({
                type: 'POST',
                url: '/Amigo/Adicionar',
                data: amigo,
                success: function () {
                    bootbox.alert('Amigo alterado com sucesso!', function () {

                        location.href = '/Amigo/Index';
                    })
                }
            })
        }
        else {
            bootbox.alert('Preencha o nome do amigo!', function () {
            })
        }

    })

    $('#btnVoltar').on('click', function () {
        window.history.back();
    })

})