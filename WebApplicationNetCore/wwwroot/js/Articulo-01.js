
// - COMPLETAR TABLA - --------------------------------------------------------------------------------------------------------
// - PREGUNTAMOS SI ESTA ELIMINADO.
// - VARIABLE BOTONES PARA QUE SE MUESTRE DEPENDIENDO DE SU ESTADO (ELIMINADO O ACTIVO).

function CompletarTablaArticulos() {
    VaciarFormulario();
    $.ajax({
        type: "POST",
        url: '../../Articulos/BuscarArticulos',
        data: {},
        success: function (articulosList) {
            $("#tbody-articulos").empty();
            $.each(articulosList, function (index, articulo) {
                let claseEliminado = '';
                let botones = '<button type="button" onclick="BuscarArticulo(' + articulo.articuloID + ')" class="btn btn-secondary btn-sm" style="margin-right:5px"><i class="bi bi-pencil-fill" style="font-size: 1.2rem; color: White;"></i></button>' +
                    '<button type="button" onclick="DesactivarActivarArticulo(' + articulo.articuloID + ',1)" class="btn btn-danger btn-sm"><i class="bi bi-eraser-fill" style="font-size: 1.2rem; color: White;"></i></button>';
                
                if (articulo.eliminado) {
                   
                    claseEliminado = 'table-danger'
                    botones = '<button type="button" onclick="DesactivarActivarArticulo(' + articulo.articuloID + ',0)" class="btn btn-warning btn-sm" style="margin-right:5px"><i class="bi bi-arrow-clockwise" style="font-size: 1.2rem; color: Black;"></i></button>';

                    $("#tbody-articulos").append('<tr class=' + claseEliminado + '>' +
                        '<td > </td>' +
                        '<td >' + articulo.descripcion + '</td>' +
                        '<td>' + articulo.ultActString + '</td>' +
                        '<td class="text-right"> $'+ articulo.precioCosto + '</td>' +
                        '<td class="text-right">' + articulo.porcentajeGanancia + '% </td>' +
                        '<td class="text-right"> $' + articulo.precioVenta + '</td>' +
                        '<td>' + articulo.subRubroNombre + '</td>' +
                        '<td>' + articulo.rubroNombre + '</td>' +
                        '<td class="text-center">' +
                        botones
                        +
                        '</td>' +
                        '</tr>');

                } else {
                    $("#tbody-articulos").append('<tr class=' + claseEliminado + '>' +
                        '<td id="cambio" onclick="BuscarSubRubro(' + articulo.articuloID + ')">' +
                        '<td >' + articulo.descripcion + '</td>' +
                        '<td>' + articulo.ultActString + '</td>' +
                        '<td class="text-right"> $' + articulo.precioCosto + '</td>' +
                        '<td class="text-right">' + articulo.porcentajeGanancia + '%</td>' +
                        '<td class="text-right"> $' + articulo.precioVenta + '</td>' +
                        '<td>' + articulo.subRubroNombre + '</td>' +
                        '<td>' + articulo.rubroNombre + '</td>' +
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
    $("#Titulo").text("Nuevo Articulo");
    $("#ArticuloID").val(0);
    $("#Articulos").modal("show");
}

// - GUARDAR - ----------------------------------------------------------------------------------------------------------------
// - VALIDACIÓN: VACÍO (.TRIM) Y NULL.

function GuardarArticulo() {
    $("#Error-ArticuloNombre").text("");
    let articuloID = $("#ArticuloID").val();
    let subRubroID = $("#SubRubroID").val();
    let articuloNombre = $("#ArticuloNombre").val().trim();
    let precioCosto = $("#PrecioCosto").val();
    let porcentajeGanancia = $("#PorcentajeGanancia").val();
    let precioVenta = $("#PrecioVenta").val();

    if (articuloNombre != "" && articuloNombre != null) {
        if (subRubroID != 0) {
        $.ajax({
            type: "POST",
            url: '../../Articulos/GuardarArticulo',
            data: { ArticuloID: articuloID, Descripcion: articuloNombre, PrecioCosto: precioCosto, PorcentajeGanancia: porcentajeGanancia, PrecioVenta: precioVenta, SubrubroID: subRubroID },
            success: function (resultado) {
                if (resultado == 0) {
                    $("#Articulos").modal("hide");
                    CompletarTablaArticulos();
                }
                if (resultado == 2) {
                    $("#Error-ArticuloNombre").text("El artículo ingresado ya existe.");
                }
               
            },
            error: function (data) {
            }
        });
        } else {
            $("#Error-ArticuloNombre").text("Debe completar los campos Rubro y Subrubro.");
        }
    }
    else {
        $("#Error-ArticuloNombre").text("Debe ingresar un artículo.");
    }
}


// - BUSCAR - -----------------------------------------------------------------------------------------------------------------
// - LLEGA EL ID. SE LO ASIGNAMOS AL HIDDEN.

function BuscarArticulo(articuloID) {
    $("#Titulo").text("Editar Artículo");
    $("#ArticuloID").val(articuloID);
    $.ajax({
        type: "POST",
        url: '../../Articulos/BuscarArticulo',
        data: { ArticuloID: articuloID },
        success: function (articulo) {
            $("#ArticuloNombre").val(articulo.descripcion);

            //LLAMO A LA FUNCION PARA QUE HAGA EL LLENADO DE LOS COMBOS, 
            //PRIMERO SE TOMA EL RUBROID PARA DESPUES EJECUTAR LA FUNCION.
            $("#RubroID").val(articulo.rubroID);
           BuscarSubRubros();

            $("#PrecioCosto").val(articulo.precioCosto);
            $("#PorcentajeGanancia").val(articulo.porcentajeGanancia);
            $("#PrecioVenta").val(articulo.precioVenta);
         
            setTimeout("$('#SubRubroID').val(articulo.subrubroID);", 1000);
            alert(articulo.subrubroID);
            $("#Articulos").modal("show");
        },
        error: function (data) {
        }
    });
}


// - VACIAR MODAL - -----------------------------------------------------------------------------------------------------------
// - ESTA FUNCIÓN LA LLAMAMOS DESDE: COMPLETAR TABLA Y DESDE LA VISTA EN EL MODAL.

function VaciarFormulario() {
    $("#ArticuloID").val(0);
    $("#ArticuloNombre").val('');

    $("#PrecioCosto").val(0);
    $("#PorcentajeGanancia").val(0);
    $("#PrecioVenta").val(0);

    $("#RubroID").val(0);
    //$("#SubRubroID").val(0);

    $("#Error-ArticuloNombre").text("");
}


// - ELIMINAR - ---------------------------------------------------------------------------------------------------------------
// - RECIBIMOS EL ID Y EL PARÁMETRO 1 O 0.

function DesactivarActivarArticulo(articuloID, elimina) {
        $.ajax({
            type: "POST",
            url: '../../Articulos/DesactivarActivarArticulo',
            data: { ArticuloID: articuloID, Elimina: elimina },
            success: function (articulo) {
                CompletarTablaArticulos();
            },
            error: function (data) {
            }
        });
    
}


// Código para armar combo de subrubro a partir de un rubro - ---------------------------------------------------------------------
// CUANDO SELECCIONO UN RUMBRO EN EL COMBO. PASA A LLAMAR A LA FUNCIÓN.
$("#RubroID").change(function () {
    BuscarSubRubros();
});

function BuscarSubRubros() {
    //Se limpia el contenido del dropdownlist
    // VACÍA EL COMBO DE SUBRUBRO.
    $("#SubRubroID").empty();
    $.ajax({
        type: 'POST',
        //Llamado al metodo en el controlador
        url: "../../SubRubros/ComboSubRubro",
        dataType: 'json',
        //Parametros que se envian al metodo del controlador. El que se seleccionó.
        data: { id: $("#RubroID").val() },
        //En caso de resultado exitoso. Tenemos como respuesta todos los Subrubros de ese Rubro.
        success: function (subRubros) {
            if (subRubros.length == 0) {
                // No existen Subrubros al Rubro seleccionado.
                $("#SubRubroID").append('<option value="' + "0" + '">' + "[NO EXISTEN SUBRUBROS]" + '</option>');
            }
            else {
                $.each(subRubros, function (i, subRubro) {
                    // Si tiene, los recorre con un foreach y los agrega uno por uno.
                    $("#SubRubroID").append('<option value="' + subRubro.value + '">' +
                        subRubro.text + '</option>');
                });
            }
        },
        ////Mensaje de error en caso de fallo
        error: function (ex) {
        }
    });
    return false;
}


// CALCULO DE PRECIO, PORCENAJE DE GANANCIA Y PRECIO DE VENTAS - ---------------------------------------------------------------

function CalcularImportes(origen) {
    let costo = $("#PrecioCosto").val();
    let ganancia = $("#PorcentajeGanancia").val();
    let venta = $("#PrecioVenta").val();

    //SI MODIFICA PRECIO DE COSTO
    if (origen == 1) {
        //CALCULAR SOLO EL PRECIO DE VENTA

        let costoCalculado = costo * ((ganancia / 100) + 1);

        $("#PrecioVenta").val(costoCalculado);
    }

    //MODIFICA EL PORCENTAJE DE GANANCIA
    if (origen == 2) {
        //CALCULAR NUEVO PRECIO DE VENTA
      
        let costoCalculado = costo * ((ganancia / 100) + 1);

        $("#PrecioVenta").val(costoCalculado);
    }
    //SI MODIFICA PRECIO DE VENTA
    if (origen == 3) {
        //calcular ganancia
        let costoCalculado = venta * 100 / costo - 100;
        $("#PorcentajeGanancia").val(costoCalculado);
    }
}
