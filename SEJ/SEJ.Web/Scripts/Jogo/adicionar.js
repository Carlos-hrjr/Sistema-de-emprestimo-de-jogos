$(document).ready(function () {

    $('#btnSalvar').on('click', function () {

        var jogo = {};

        jogo.Descricao = $('#txtDescricao').val();
        jogo.Valor = $('#txtValor').val();
        jogo.Distribuidora = $('#txtDistribuidora').val();

        if (jogo.Descricao == '') {
            bootbox.alert('Digite a descrição!', function () {

            })
        } else if (jogo.Valor == '') {
            bootbox.alert('Digite o valor!', function () {

            })
        } else {
            $.ajax({
                type: 'POST',
                url: '/Jogo/Adicionar',
                data: jogo,
                success: function () {
                    bootbox.alert('Jogo cadastrado com sucesso!', function () {

                        location.href = '/Jogo/Index';
                    })
                }
            })
        }
    })

    $('#btnVoltar').on('click', function () {
        window.history.back();
    })

})