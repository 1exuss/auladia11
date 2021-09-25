$(document).ready(function () {
    $('#busca').keypress(function (e) {
        if (e.which === 13) {
            load();
        }
    });
    load();
});

function load() {
    let nome = $('[name="nome"]').val();
    let pesoMaiorQue = ($('[name="pesoMaiorQue"]').val() || 0);
    let pesoMenorQue = ($('[name="pesoMenorQue"]').val() || 0);
    PessoaListaPessoas(nome, pesoMaiorQue, pesoMenorQue).then(function (data) {
        $('#table tbody').html('');
        data.forEach(obj => {
            let btnRemover = '<button class="btn btn-danger" onclick="remover(\'' + obj.id + '\')"><i class="fa fa-trash"></button>';
            let btnEditar = '<button class="btn btn-info" onclick="window.location.href = \'/pessoa/formulario/' + obj.id + '\'"><i class="fa fa-edit"></i> Editar</button>';
           // let id = "'" + obj.id + "'";
            $('#table tbody').append('' +
                '<tr id="obj-' + obj.id + '">' +
                '<td>' + (obj.nome || '--') + '</td>' +
                '<td>' + (obj.peso || '--') + '</td>' +
                '<td>' + (moment(obj.dataNascimento).format('DD/MM/YYYY') || '--') + '</td>' +
                '<td>' + (obj.cidade.nome || '--') + '</td>' +
                '<td>' + (obj.ativo === true ? 'Ativo' : 'Inativo') + '</td>' +
                '<td>' + (obj.telefone || '--') + '</td>' +
                '<td>' + (obj.cpf || '--') + '</td>' +
                '<td>' + btnEditar + btnRemover + '</td>' +
                '</tr>');
        });
        $('#table-pessoas').DataTable();
    });
}
function remover(id) {
    PessoaRemover(id).then(function () {
        alert("Pessoa Removida com Sucesso");
        load();
    })
}

