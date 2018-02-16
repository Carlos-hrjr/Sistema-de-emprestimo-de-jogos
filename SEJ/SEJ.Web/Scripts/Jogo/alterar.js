$(document).ready(function () {

    $('#btnSalvar').on('click', function () {

        var jogo = {};

        jogo.Id = $('#hdnId').val();
        jogo.Descricao = $('#txtDescricao').val();
        jogo.Valor = $('#txtValor').val();
        jogo.Distribuidora = $('#txtDistribuidora').val();

        $.ajax({
            type: 'POST',
            url: '/Jogo/Adicionar',
            data: jogo,
            success: function () {
                bootbox.confirm('Jogo alterado com sucesso!', function () {

                    location.href = '/Jogo/Index';
                })
            }
        })
    })

    $('#btnVoltar').on('click', function () {
        window.history.back();
    })

})