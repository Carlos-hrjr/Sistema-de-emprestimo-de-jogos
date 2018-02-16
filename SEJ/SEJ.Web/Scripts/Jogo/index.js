$(document).ready(function () {

    $('#btnAdicionar').on('click', function () {
        location.href = '/Jogo/Adicionar';
    })

    $("#tabelaJogos").on('click','.btnExcluir',function(){
         
         var currentRow=$(this).closest("tr"); 

         var idJogo = {};
         idJogo.id = currentRow.find("td:eq(0)").text(); 
         
         $.ajax({
             type: 'POST',
             url: '/Jogo/Excluir',
             data: { id: idJogo.id },
             success: function () {
                 bootbox.alert('Jogo excluído com sucesso!', function () {

                     location.href = '/Jogo/Index';
                 });
             },
             error: function () {
                 bootbox.alert('Jogo não pode ser excluído pois existe um empréstimo vinculado a ele', function () {
                     location.href = '/Jogo/Index';
                 });
             }
         })
    });

    $("#tabelaJogos").on('click', '.btnAlterar', function () {
       
        var currentRow = $(this).closest("tr");

        var idJogo = {};
        idJogo.id = parseInt(currentRow.find("td:eq(0)").text()); 

        location.href = '/Jogo/Alterar/' + idJogo.id;
    });

})