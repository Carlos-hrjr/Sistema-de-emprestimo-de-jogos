$(document).ready(function () {

    $('#btnAdicionar').on('click', function () {
        location.href = '/Emprestimo/Adicionar';
    })

    $('#btnHistorico').on('click', function () {
        location.href = '/Emprestimo/Historico';
    })

    $("#tabelaEmprestimos").on('click', '.btnDevolver', function () {
        
        var currentRow = $(this).closest("tr");

        var idEmprestimo = {};
        idEmprestimo.id = currentRow.find("td:eq(0)").text(); 

        $.ajax({
            type: 'POST',
            url: '/Emprestimo/Devolver',
            data: { id: idEmprestimo.id },
            success: function () {
                bootbox.alert('Empréstimo devolvido com sucesso!', function () {

                    location.href = '/Emprestimo/Index';
                });
            }
        })
    });

})