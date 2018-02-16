$(document).ready(function () {

    $('#btnAdicionar').on('click', function () {
        location.href = '/Amigo/Adicionar';
    })

    $("#tabelaAmigos").on('click', '.btnExcluir', function () {
       
        var currentRow = $(this).closest("tr");

        var idAmigo = {};
        idAmigo.id = currentRow.find("td:eq(0)").text(); 

        $.ajax({
            type: 'POST',
            url: '/Amigo/Excluir',
            data: { id: idAmigo.id },
            success: function () {
                bootbox.confirm('Amigo excluído com sucesso!', function () {

                    location.href = '/Amigo/Index';
                })
            },
            error: function () {
                bootbox.confirm('Amigo não pode ser excluído pois existe um empréstimo vinculado a ele', function () {
                    location.href = '/Amigo/Index';
                });
            }
        })
    });

    $("#tabelaAmigos").on('click', '.btnAlterar', function () {
        
        var currentRow = $(this).closest("tr");

        var idAmigo = {};
        idAmigo.id = parseInt(currentRow.find("td:eq(0)").text()); 

        location.href = '/Amigo/Alterar/' + idAmigo.id;
    });

})