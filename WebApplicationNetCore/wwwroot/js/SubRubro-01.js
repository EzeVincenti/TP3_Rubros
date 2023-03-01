
// - COMPLETAR TABLA - --------------------------------------------------------------------------------------------------------
// - PREGUNTAMOS SI ESTA ELIMINADO.
// - VARIABLE BOTONES PARA QUE SE MUESTRE DEPENDIENDO DE SU ESTADO (ELIMINADO O ACTIVO).

function CompletarTablaSubRubros() {
    VaciarFormulario();
    $.ajax({
        type: "POST",
        url: '../../SubRubros/BuscarSubRubros',
        data: {},
        success: function (subrubrosList) {
            $("#tbody-subrubros").empty();
            $.each(subrubrosList, function (index, subrubro) {

                // - VARIABLES ACTIVO. NO TIENE CLASE (FONDO BLANCO). DOS BOTONES. PARÁMETRO 1.
                let claseEliminado = '';
                let botones = '<button type="button" onclick="BuscarSubRubro(' + subrubro.subRubroID + ')" class="btn btn-secondary btn-sm" style="margin-right:5px"><i class="bi bi-pencil-fill" style="font-size: 1.2rem; color: White;"></i></button>' +
                    '<button type="button" onclick="DesactivarActivarSubRubro(' + subrubro.subRubroID + ',1)" class="btn btn-danger btn-sm"><i class="bi bi-eraser-fill" style="font-size: 1.2rem; color: White;"></i></button>';
                
                // - VARIABLE ELIMINADO. TIENE CLASE (ROJO). UN BOTÓN. PARÁMETRO 0.
                if (subrubro.eliminado) {
                   
                    claseEliminado = 'table-danger'
                    botones = '<button type="button" onclick="DesactivarActivarSubRubro(' + subrubro.subRubroID + ',0)" class="btn btn-warning btn-sm" style="margin-right:5px"><i class="bi bi-arrow-clockwise" style="font-size: 1.2rem; color: Black;"></i></button>';

                    $("#tbody-subrubros").append('<tr class=' + claseEliminado + '>' +
                        '<td >' + subrubro.descripcion + '</td>' +
                        '<td>' + subrubro.rubroNombre + '</td>' +
                        '<td class="text-center">' +
                        botones
                        +
                        '</td>' +
                        '</tr>');

                } else {
                    $("#tbody-subrubros").append('<tr class=' + claseEliminado + '>' +
                        '<td id="cambio" onclick="BuscarSubRubro(' + subrubro.subRubroID + ')">' + subrubro.descripcion + '</td>'+
                        '<td>' + subrubro.rubroNombre + '</td>' +
                        '<td class="text-center">' +
                        botones
                        +
                        '</td>' +
                        '</tr>');

                }
                                
            });
        },
        error: function (data) {

        }
    });
}


// - ABRIR MODAL - ------------------------------------------------------------------------------------------------------------

function AbrirModal() {
    $("#Titulo").text("Nuevo Subrubro");
    $("#SubrubroID").val(0);
    $("#Subrubros").modal("show");

}


// - GUARDAR - ----------------------------------------------------------------------------------------------------------------
// - VALIDACIÓN: VACÍO (.TRIM) Y NULL.

function GuardarSubRubro() {
    $("#Error-SubRubroNombre").text("");
    let subrubroID = $("#SubRubroID").val();
    let rubroID = $("#RubrosID").val();
    let subrubroNombre = $("#SubRubroNombre").val().trim();
    if (subrubroNombre != "" && subrubroNombre != null) {

        $.ajax({
            type: "POST",
            url: '../../SubRubros/GuardarSubRubro',
            data: { SubRubroID: subrubroID, Descripcion: subrubroNombre, RubroID: rubroID },
            success: function (resultado) {

                // - Si es 0, se guarda.
                if (resultado == 0) {
                    $("#Subrubros").modal("hide");
                    CompletarTablaSubRubros();
                }

                // - Si es 2, existe.
                if (resultado == 2) {
                    $("#Error-SubRubroNombre").text("El subrubro ingresado ya existe.");
                }
               
            },
            error: function (data) {
            }
        });
    }
       // - MENSAJE SI LLEGA NULO O VACÍO.
    else {
        $("#Error-SubRubroNombre").text("Debe ingresar un nuevo subrubro.");
    }

}


// - BUSCAR - -----------------------------------------------------------------------------------------------------------------
// - LLEGA EL ID. SE LO ASIGNAMOS AL HIDDEN.

function BuscarSubRubro(subrubroID) {
    $("#Titulo").text("Editar SubRubro");
    $("#SubRubroID").val(subrubroID);
    $.ajax({
        type: "POST",
        url: '../../SubRubros/BuscarSubRubro',
        data: { SubRubroID: subrubroID },
        success: function (subrubro) {
            $("#SubRubroNombre").val(subrubro.descripcion);
            $("#RubrosID").val(subrubro.rubroID);

            $("#Subrubros").modal("show");
        },
        error: function (data) {
        }
    });
}


// - VACIAR MODAL - -----------------------------------------------------------------------------------------------------------
// - ESTA FUNCIÓN LA LLAMAMOS DESDE: COMPLETAR TABLA Y DESDE LA VISTA EN EL MODAL.

function VaciarFormulario() {
    $("#SubRubroID").val(0);
    $("#SubRubroNombre").val('');
    $("#Error-SubRubroNombre").text("");
}


// - ELIMINAR - ---------------------------------------------------------------------------------------------------------------
// - RECIBIMOS EL ID Y EL PARÁMETRO 1 O 0.

function DesactivarActivarSubRubro(subrubroID, elimina) {
    //if (elimina == 1) {
    //    var texto = "Está Seguro de Borrar el Sub Rubro ?"
    //} else {
    //    var texto = "Está Seguro de Activar el Sub Rubro ?"
    //}
    //if (confirm(texto)) {
        $.ajax({
            type: "POST",
            url: '../../SubRubros/DesactivarActivarSubRubro',
            data: { SubRubroID: subrubroID, Elimina: elimina },
            success: function (subrubro) {
                CompletarTablaSubRubros();
            },
            error: function (data) {
            }
        });
    
}

