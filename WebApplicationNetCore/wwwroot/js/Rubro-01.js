
// - COMPLETAR TABLA - --------------------------------------------------------------------------------------------------------
// - PREGUNTAMOS SI ESTA ELIMINADO.
// - VARIABLE BOTONES PARA QUE SE MUESTRE DEPENDIENDO DE SU ESTADO (ELIMINADO O ACTIVO).

function CompletarTablaRubros() {
    VaciarFormulario();
    $.ajax({
        type: "POST",
        url: '../../Rubros/BuscarRubros',
        data: {},
        success: function (listadoRubros) {
            $("#tbody-rubros").empty();
            $.each(listadoRubros, function (index, rubro) {

                // - VARIABLES ACTIVO. NO TIENE CLASE (FONDO BLANCO). DOS BOTONES. PARÁMETRO 1.
                let claseEliminado = '';
                let botones = '<button type="button" onclick="BuscarRubro(' + rubro.rubroID + ')" class="btn btn-secondary btn-sm" style="margin-right:5px"><i class="bi bi-pencil-fill" style="font-size: 1.2rem; color: White;"></i></button>' +
                    '<button type="button" onclick="DesactivarActivarRubro(' + rubro.rubroID + ',1)" class="btn btn-danger btn-sm"><i class="bi bi-eraser-fill" style="font-size: 1.2rem; color: White;"></i></button>';

                // - VARIABLE ELIMINADO. TIENE CLASE (ROJO). UN BOTÓN. PARÁMETRO 0.
                if (rubro.eliminado) {
                    claseEliminado = 'table-danger'
                    botones = '<button type="button" onclick="DesactivarActivarRubro(' + rubro.rubroID + ',0)" class="btn btn-warning btn-sm" style="margin-right:5px"><i class="bi bi-arrow-clockwise" style="font-size: 1.2rem; color: Black;"></i></button>';

                    $("#tbody-rubros").append('<tr class=' + claseEliminado + '>' +
                        '<td >' + rubro.descripcion + '</td>' +
                        '<td class="text-center">' +
                        botones
                        +
                        '</td>' +
                        '</tr>');

                } else {
                    $("#tbody-rubros").append('<tr class=' + claseEliminado + '>' +
                        '<td id="cambio" onclick="BuscarRubro(' + rubro.rubroID + ')">' + rubro.descripcion + '</td>' +
                        '<td class="text-center">' +
                        botones
                        +
                        '</td>' +
                        '</tr>');
                }


                //$("#tbody-rubros").append('<tr class=' + claseEliminado +'>' +
                //    '<td id="cambio" onclick="BuscarRubro(' + rubro.rubroID + ')">' + rubro.descripcion + '</td>' +
                //    '<td class="text-center">' +
                //    botones
                //     +
                //    '</td>' +
                //    '</tr>');
              
            });
        },
        error: function (data) {

        }
    });
}


// - ABRIR MODAL - ------------------------------------------------------------------------------------------------------------

function AbrirModal() {
    $("#Titulo").text("Nuevo Rubro");
    $("#RubroID").val(0);
    $("#Rubros").modal("show");
}


// - GUARDAR - ----------------------------------------------------------------------------------------------------------------
// - VALIDACIÓN: VACÍO (.TRIM) Y NULL.

function GuardarRubro() {
    $("#Error-RubroNombre").text("");
    let rubroID = $("#RubroID").val().trim();
    let rubroNombre = $("#RubroNombre").val().trim();
    if (rubroNombre != "" && rubroNombre != null) {

        $.ajax({
            type: "POST",
            url: '../../Rubros/GuardarRubro',
            data: { RubroID: rubroID, Descripcion: rubroNombre },
            success: function (resultado) {

                // - Si es 0, se guarda.
                if (resultado == 0) {
                    $("#Rubros").modal("hide");
                    CompletarTablaRubros();
                }
                // - Si es 2, existe.
                if (resultado == 2) {
                    $("#Error-RubroNombre").text("El Rubro ingresado ya existe.");
                }
               
            },
            error: function (data) {
            }
        });
    }
     // - MENSAJE SI LLEGA NULO O VACÍO.
    else {
        $("#Error-RubroNombre").text("Debe ingresar un nuevo rubro.");
    }

}


// - BUSCAR EDITAR - -------------------------------------------------------------------------------------------------------------
// - LLEGA EL ID. SE LO ASIGNAMOS AL HIDDEN.

function BuscarRubro(rubroID) {
    $("#Titulo").text("Editar Rubro");
    $("#RubroID").val(rubroID);
    $.ajax({
        type: "POST",
        url: '../../Rubros/BuscarRubro',
        data: { RubroID: rubroID },
        success: function (rubro) {
            $("#RubroNombre").val(rubro.descripcion);
            $("#Rubros").modal("show");
        },
        error: function (data) {
        }
    });
}


// - VACIAR MODAL - -----------------------------------------------------------------------------------------------------------
// - ESTA FUNCIÓN LA LLAMAMOS DESDE: COMPLETAR TABLA Y DESDE LA VISTA EN EL MODAL.

function VaciarFormulario() {
    $("#RubroID").val(0);
    $("#RubroNombre").val('');
    $("#Error-RubroNombre").text("");
}


// - ELIMINAR - ---------------------------------------------------------------------------------------------------------------
// - RECIBIMOS EL ID Y EL PARÁMETRO 1 O 0.

function DesactivarActivarRubro(rubroID,elimina) {
    //if (elimina == 1) {
    //    var texto = "Está Seguro de Borrar el Rubro ?"
    //} else {
    //    var texto = "Está Seguro de Activar el Rubro ?"
    //}
    //if (confirm(texto)) {

        $.ajax({
            type: "POST",
            url: '../../Rubros/DesactivarActivarRubro',
            data: { RubroID: rubroID, Elimina: elimina },
            success: function (rubro) {
                CompletarTablaRubros();
            },
            error: function (data) {
            }       
 
        });
    }
