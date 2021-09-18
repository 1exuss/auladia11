$(document).ready(function () {
    $('#busca').keypress(function (e) {
        if (e.which === 13) {
            load();
        }
    });
    load();
});

function load() {
    let pessoa = $('[name="busca"]').val();
    PessoaListaPessoas(pessoa).then(function (data) {
        $('#table tbody').html('');
        data.forEach(obj => {
            $('#table tbody').append('' +
                '<tr id="obj-' + obj.id + '">' +
                '<td>' + (obj.nome || '--') + '</td>' +
                '<td>' + (moment(obj.dataNascimento || '--').format('dd/mm/yyyy'))+ '</td>' +
                '<td>' + (obj.peso || '--') + '</td>' +
                '<td>' + (obj.ativo || '--') + '</td>' +
                '</tr>');
        });
    });
}

