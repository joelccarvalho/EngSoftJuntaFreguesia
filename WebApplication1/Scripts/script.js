// Mostrar ou esconder form da checkbox escolhida
$(document).ready(function () {
    $('#userRadio').click(function () {
        $('.form-group-checkbox-postalCode').hide();
        $('.form-group-checkbox-user').show();
    });
    $('#userPostalCode').click(function () {
        $('.form-group-checkbox-user').hide();
        $('.form-group-checkbox-postalCode').show();
    });
});

// Acrescentar como default campo vazio na dropdown IdCodigoPostal (InformacoesUteis/Create)
$(document).ready(function () {
    var new_empty = new Option("", "", false, true);
    $(new_empty).html("");
    $("#IdCodigoPostal").append(new_empty);
});

// Acrescentar como default campo vazio na dropdown Destinatario (InformacoesUteis/Create)
$(document).ready(function () {
    var new_empty = new Option("", "", false, true);
    $(new_empty).html("");
    $("#Destinatario").append(new_empty);
});
