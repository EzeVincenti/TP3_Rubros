using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationNetCore.Data;
using WebApplicationNetCore.Models;

namespace WebApplicationNetCore.Controllers
{
    public class RubrosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RubrosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Rubros
        public async Task<IActionResult> Index()
        {
            return View(await _context.Rubro.ToListAsync());
        }

        // - BUSCAR RUBRO - MOSTRAR LISTA ------------------------------------------------------------------------------

        public JsonResult BuscarRubros()
        {
            var rubros = _context.Rubro.ToList();

            return Json(rubros);
        }

        // - GUARDAR - EDITAR - ------------------------------------------------------------------------------------------

        public JsonResult GuardarRubro(int RubroID, string Descripcion)
        {
            int resultado = 0;
            // SI ES 0, ES CORRECTO.
            // SI ES 1, ES CAMPO DESCRIPCIÓN VACÍO.
            // SI ES 2, ES CAMPO DESCRIPCIÓN YA EXISTE.

            // PREGUNTAMOS SI DESCRIPCIÓN ES DISTINTO A NULL O VACIO. SI ES ASÍ, HACE TODO EL RESTO.
            if (!string.IsNullOrEmpty(Descripcion))
            {
                Descripcion = Descripcion.ToUpper();
                if (RubroID == 0)
                {
                    // ANTES DE CREAR UN REGISTRO PREGUNTAMOS SI EXISTE CON LA MISMA DESCRIPCIÓN.
                    if (_context.Rubro.Any(e => e.Descripcion == Descripcion))
                    {
                        resultado = 2;
                    }
                    else {

                        // CREA EL REGISTRO DE RUBRO. - -------------------------------------
                        // PARA ESO CREAMOS UN OBJETO DE TIPO RUBRO CON LOS DATOS NECESARIOS.
                        var rubrocrear = new Rubro
                        {
                            Descripcion = Descripcion
                        };

                        _context.Add(rubrocrear);
                        _context.SaveChanges();
                    }
                }
                else
                {
                    if (_context.Rubro.Any(e => e.Descripcion == Descripcion && e.RubroID != RubroID))
                    {
                        resultado = 2;
                    }
                    else
                    {
                        // EDITA EL REGISTRO. - ----------------------------------------------
                        // BUSCAMOS EL REGISTRO EN LA BASE DE DATOS
                        // CREA UNA VARIABLE. BUSCA EN LA DB LA TABLA RUBRO. RECIBE UN PARAMETRO (SINGLE).
                        // CAMPO DE LA TABLA SE COMPARA A LA VARIABLE QUE SE RECIBE DE LA VISTA. LA "M" ES EL OBJETO COMPLETO.
                        var rubro = _context.Rubro.Single(m => m.RubroID == RubroID);

                        //CAMBIAMOS LA DESCRIPCIÓN POR LA QUE INGRESÓ EL USUARIO EN LA VISTA. MODIFICAMOS SOLO ESE CAMPO.
                        rubro.Descripcion = Descripcion;
                        _context.SaveChanges();
                    }
   
                }
            }
            else
            {
                resultado = 1;
            }
     
            return Json(resultado);
        }

        // - BUSCAR RUBRO - PARA EDITARLO. SINGULAR ------------------------------------------------------------------------------

        public JsonResult BuscarRubro(int RubroID)
        {
            var rubro = _context.Rubro.FirstOrDefault(m => m.RubroID == RubroID);

            return Json(rubro);
        }

        // - ELIMINAR - ---------------------------------------------------------------------------------------------------
        // - PREGUNTAMOS SI ES 1 O 0 PARA CAMBIAR SU ESTADO.

        public JsonResult DesactivarActivarRubro(int RubroID, int Elimina)
        {
            bool resultado = true;

            var rubro = _context.Rubro.Find(RubroID);
            if (rubro != null)
            {
                if (Elimina == 0)
                {
                    rubro.Eliminado = false;
                }
                else
                {
                    rubro.Eliminado = true;
                }
                
                _context.SaveChanges();
            }

            return Json(resultado);
        }

        private bool RubroExists(int id)
        {
            return _context.Rubro.Any(e => e.RubroID == id);
        }
    }
}
