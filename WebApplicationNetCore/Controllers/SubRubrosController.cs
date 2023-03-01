using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationNetCore.Data;
using WebApplicationNetCore.Models;

namespace WebApplicationNetCore.Controllers
{
    public class SubRubrosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SubRubrosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SubRubros
        public IActionResult Index()
        {
            //CREAMOS OBJETO EN FORMA DE LISTA CON LOS RUBROS ACTIVOS
            var rubros = _context.Rubro.Where(p=> p.Eliminado == false ).ToList();

            //CARGAMOS UNA LISTA ORDENADA DE RUBROS DONDE INCLUIMOS 2 PARAMETROS.
            //// EL RUBRO COINCIDE CON EL COMBO.
            ViewBag.RubrosID = new SelectList(rubros.OrderBy(p => p.Descripcion), "RubroID", "Descripcion");
                       
            return View();
        }

        // - BUSCAR SUBRUBRO - ---------------------------------------------------------------------------------------------------
        public JsonResult BuscarSubRubros()
        {
            // CREAMOS UNA OBJETO LIST EN BLANCO DONDE INCLUYA RUBROS.
           var subrubros = _context.Subrubro.Include(r=> r.Rubro).ToList();
                      
          
            // CREAMOS LISTA PARA PODER MOSTRAR SOBRE EL MODELO CREADO. 
            List <SubRubroMostrar> subrubrosList = new List<SubRubroMostrar>();
            
            // CARGAMOS EN EL OBJETO CREADO RECORRIENDO LA TABLA.
            // LO QUE VAMOS A RECORRER. EL NEW DECLARA UN NUEVO OBJETO.
            // SINGULAR, UN ELEMENTO. PLURAR, MUCHOS ELEMENTOS.
            foreach (var subrubro in subrubros)
            {
                var subrubromostrar = new SubRubroMostrar()
                {
                    // HAY QUE PASAR SI O SI TODOS LOS PARAMETROS PARA QUE SE ARME EL OBJETO A MOSTRAR Y PODAMOS HACER
                    // LAS VERIFICACIONES CORRESPONDIENTES EN LA VISTA 
                    SubRubroID = subrubro.SubRubroID,
                    Descripcion = subrubro.Descripcion,
                    RubroID = subrubro.RubroID,
                    RubroNombre = subrubro.Rubro.Descripcion,
                   
                    // ESTE ES EL PARAMETRO QUE FALTABA PARA PODER BORRAR
                    Eliminado = subrubro.Eliminado,
                };
                subrubrosList.Add(subrubromostrar);
                
            }
            return Json(subrubrosList);
        }


        // - GUARDAR - EDITAR - ------------------------------------------------------------------------------------------

        public JsonResult GuardarSubRubro(int SubRubroID, string Descripcion, int RubroID)
        {
            // TODO MAYUSCULA. PREGUNTAR
            int resultado = 0;

            // SI ES 0, ES CORRECTO.
            // SI ES 1, ES CAMPO DESCRIPCIÓN VACÍO.
            // SI ES 2, ES CAMPO DESCRIPCIÓN YA EXISTE.

            // PREGUNTAMOS SI DESCRIPCIÓN ES DISTINTO A NULL O VACIO. SI ES ASÍ, HACE TODO EL RESTO.
            if (!string.IsNullOrEmpty(Descripcion))
            {
                Descripcion = Descripcion.ToUpper();
                if (SubRubroID == 0)
                {

                    // ANTES DE CREAR UN REGISTRO PREGUNTAMOS SI EXISTE CON LA MISMA DESCRIPCIÓN.
                    // SI PERTENECE AL MISMO RUBRO, ACLARAR.
                    if (_context.Subrubro.Any(e => e.Descripcion == Descripcion && e.RubroID == RubroID))
                    {
                        resultado = 2;
                    }
                    else
                    {

                        //GRABA SI PASA TODA LA VERIFICACION, POR DEFECTO LOS PARAMETROS ID Y BOOLEAN 
                        // CREA EL REGISTRO DE RUBRO. - -------------------------------------
                        // PARA ESO CREAMOS UN OBJETO DE TIPO SUBRUBRO CON LOS DATOS NECESARIOS.

                        var subrubrocrear = new Subrubro
                        {
                            Descripcion = Descripcion, 
                            RubroID = RubroID
                        };

                        _context.Add(subrubrocrear);
                        _context.SaveChanges();
                    }
                }
                else
                {
                    if (_context.Subrubro.Any(e => e.Descripcion == Descripcion && e.SubRubroID != SubRubroID))
                    {
                        resultado = 2;
                    }
                    else
                    {
                        // EDITA EL REGISTRO. - ----------------------------------------------
                        // BUSCAMOS EL REGISTRO EN LA BASE DE DATOS
                        // CREA UNA VARIABLE. BUSCA EN LA DB LA TABLA RUBRO. RECIBE UN PARAMETRO (SINGLE).
                        // CAMPO DE LA TABLA SE COMPARA A LA VARIABLE QUE SE RECIBE DE LA VISTA. LA "M" ES EL OBJETO COMPLETO.


                        var subrubro = _context.Subrubro.Single(m => m.SubRubroID == SubRubroID);
                        //CAMBIAMOS LA DESCRIPCIÓN POR LA QUE INGRESÓ EL USUARIO EN LA VISTA. MODIFICAMOS SOLO ESOS CAMPOS.
                        subrubro.Descripcion = Descripcion;
                        subrubro.RubroID = RubroID;
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

        public JsonResult BuscarSubRubro(int SubRubroID)
        {
            //CREAMOS EL OBJETO BUSCADO CON EL PARAMETRO QUE ENVIAMOS CON JS.
            var subrubro = _context.Subrubro.FirstOrDefault(m => m.SubRubroID == SubRubroID);

            return Json(subrubro);
        }


        // - ELIMINAR - -------------------------------------------------------------------------------------------------------
        // - PREGUNTAMOS SI ES 1 O 0 PARA CAMBIAR SU ESTADO.
        public JsonResult DesactivarActivarSubRubro(int SubRubroID, int Elimina)
        {
            bool resultado = true;
            //BUSCANDO EN TABLA EL ELEMENTEO CON ID Y CREO EL OBJETO
            var subrubro = _context.Subrubro.Find(SubRubroID);
            if (subrubro != null)
            {
                if (Elimina == 0)
                {
                    subrubro.Eliminado = false;
                }
                else
                {
                    subrubro.Eliminado = true;
                }

                _context.SaveChanges();
            }

            return Json(resultado);
        }


        // COMBO SUBRUBRO PARA EL MODAL DE ARTÍCULOS. - --------------------------------------------------------------------------
        public JsonResult ComboSubRubro(int id)//RUBRO ID DEL QUE SE SELECCIONÓ EN EL COMBO.
        {
            //BUSCAR SUBRUBROS, CUANDO EL RUBRO ID ES IGUAL AL QUE ESTAMOS PASANDO EN EL PARÁMERO.
            var subRubros = (from o in _context.Subrubro where o.RubroID == id && o.Eliminado == false select o).ToList();

            // DEVUELVE UN SELECTLIST.
            return Json(new SelectList(subRubros, "SubRubroID", "Descripcion"));
        }




        private bool SubRubroExists(int id)
        {
            return _context.Subrubro.Any(e => e.SubRubroID == id);
        }
    
    }
}
