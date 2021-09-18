function salvar() {
    let obj = {
        nome: ($("[name='nome']").val() || ''),
        dataNascimento: ($("[name='dataNascimento']").val() || ''),
        peso: ($("[name='peso']").val() || ''),
        ativo: true
    };
    PessoaSalvar(obj).then(function () {
        window.location.href = '/pessoas';
    }, function (err) {
        alert(err);
    });
}
