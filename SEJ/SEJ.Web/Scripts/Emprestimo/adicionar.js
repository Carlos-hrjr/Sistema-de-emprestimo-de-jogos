$(document).ready(function () {

    $('#btnSalvar').on('click', function () {

        var emprestimo = {};
        emprestimo.IdJogo = $('#jogos').val();
        emprestimo.IdAmigo = $('#amigos').val();

        if (emprestimo.IdJogo == '') {
            bootbox.alert('Selecione um jogo!', function () {

            })
        } else if (emprestimo.IdAmigo == '') {
            bootbox.alert('Selecione um amigo!', function () {

            })
        } else {
            $.ajax({
                type: 'POST',
                url: '/Emprestimo/Adicionar',
                data: emprestimo,
                success: function () {
                    bootbox.alert('Emprestimo cadastrado com sucesso!', function () {
                        location.href = '/Emprestimo/Index';
                    });
                }
            })
        }
        
    })

    $('#btnVoltar').on('click', function () {
        window.history.back();
    })

})
