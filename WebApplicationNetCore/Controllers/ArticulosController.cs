using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApplicationNetCore.Data;
using WebApplicationNetCore.Models;







namespace WebApplicationNetCore.Controllers
{
    public class ArticulosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ArticulosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Articulos
        public IActionResult Index()
        {
            // CREAMOS OBJETO EN FORMA DE LISTA CON LOS SUBRUBRO ACTIVOS.
            // VARIABLE, QUE BUSCA EN LA TABLA RUBROS DONDE NO ESTEN ELIMINADOS Y LOS TRAE EN FORMA DE LISTADO.
            // ESE LISTADO LO PASAMOS EN UN SELECLIST PARA MOSTRARLO EN FORMA DE COMBO.
            // (LINEA DEL MEDIO) A LA VARIABLE LE AGREGAMOS UNO NUEVO EN MEMORIA PARA MOSTRAR EN PANTALLA. CON ID CERO.
            // LUEGO VALIDAMOS QUE EL ARTÍCULO SE PUEDA GUARDAR SI EL RUBRO ES MAYOR A CERO.
            // CUANDO SELECCIONO UN RUBRO, HACE LA VALIDACIÓN PARA QUE DESENCADENE EL COMBO SUBRUBRO.
            var rubros = _context.Rubro.Where(p => p.Eliminado == false).ToList();
            rubros.Add(new Rubro { RubroID = 0, Descripcion = "[SELECCIONE UN RUBRO]" });
            ViewBag.RubroID = new SelectList(rubros.OrderBy(p => p.Descripcion), "RubroID", "Descripcion");

            // CARGAMOS UNA LISTA ORDENADA DE RUBROS DONDE INCLUIMOS 2 PARAMETROS 
            // EL COMBO DE SUBRUBRO SE MUESTRA VACÍO.
            // VARIABLE EN FORMA DE LISTADO, QUE ESTA VACÍA. NO BUSCA EN BASE DE DATOS.
            // LE AGREGAMOS UN ELEMENTO NUEVO. CON UN TEXTO.
            // LISTADO VACÍO.
            List<Subrubro> subrubros = new List<Subrubro>();
            subrubros.Add(new Subrubro { SubRubroID = 0, Descripcion = "[SELECCIONE UN SUBRUBRO]" });
            ViewBag.SubRubroID = new SelectList(subrubros.OrderBy(p => p.Descripcion), "SubRubroID", "Descripcion");


            return View();
        }

        public JsonResult BuscarArticulos()
        {
            //CREAMOS UNA OBJETO LIST EN BLANCO DONDE INCLUYA SUBRUBROS
            var articulos = _context.Articulo.Include(s => s.Subrubro).Include(f => f.Subrubro.Rubro).ToList();
            //CREAMOS LISTA PARA PODER MOSTRAR SOBRE EL MODELO CREADO 
            List<ArticuloMostrar> articulosList = new List<ArticuloMostrar>();
            //CARGAMOS EN EL OBJETO CREADO RECORRIENDO LA TABLA 
            foreach (var articulo in articulos)
            {
                var articulomostrar = new ArticuloMostrar()
                {
                    //HAY QUE PASAR SI O SI TODOS LOS PARAMETROS PARA QUE SE ARME EL OBJETO A MOSTRAR Y PODAMOS HACER
                    //LAS VERIFICACIONES CORRESPONDIENTES EN LA VISTA 
                    ArticuloID = articulo.ArticuloID,
                    Descripcion = articulo.Descripcion,
                    UltAct = articulo.UltAct,
                    UltActString = articulo.UltAct.ToString("dd-MM-yyyy"),
                    PrecioCosto = articulo.PrecioCosto,
                    PorcentajeGanancia = articulo.PorcentajeGanancia,
                    PrecioVenta = articulo.PrecioVenta,
                    SubrubroID = articulo.SubrubroID,
                    SubRubroNombre = articulo.Subrubro.Descripcion,
                    //RubroID = articulo.Subrubro.RubroID,
                    RubroNombre = articulo.Subrubro.Rubro.Descripcion,

                    //ESTE ES EL PARAMETRO QUE FALTABA PARA PODER BORRAR
                    Eliminado = articulo.Eliminado,

                 };
                articulosList.Add(articulomostrar);

            }
            return Json(articulosList);
        }

        public JsonResult GuardarArticulo(int ArticuloID, string Descripcion, decimal PrecioCosto, decimal PorcentajeGanancia, decimal PrecioVenta, int SubRubroID)
        {

            int resultado = 0;

            // CONFIGURACIÓN DE CULTURA ESPAÑOL ARGENTINA
           // Thread.CurrentThread.culture = new CultureInfo("es-AR");


            if (!string.IsNullOrEmpty(Descripcion))
            {
                Descripcion = Descripcion.ToUpper();
                if (ArticuloID == 0)
                {
                    if (_context.Articulo.Any(e => e.Descripcion == Descripcion && e.ArticuloID == ArticuloID))
                    {
                        resultado = 2;
                    }
                    else
                    {
                        //GRABA SI PASA TODA LA VERIFICACION, POR DEFECTO LOS PARAMETROS ID Y BOOLEAN 

                        var articulocrear = new Articulo
                        {
                            Descripcion = Descripcion,
                            UltAct = DateTime.Now,
                            PrecioCosto = PrecioCosto,
                            PorcentajeGanancia = PorcentajeGanancia,
                            PrecioVenta = PrecioVenta,
                            SubrubroID = SubRubroID,
                           
                        };

                        _context.Add(articulocrear);
                        _context.SaveChanges();
                    }
                }
                else
                {
                    if (_context.Articulo.Any(e => e.Descripcion == Descripcion && e.ArticuloID != ArticuloID))
                    {
                        resultado = 2;
                    }
                    else
                    {
                        //EDITA EL REGISTRO
                        //BUSCAMOS EL REGISTRO EN LA BASE DE DATOS

                        var articulo = _context.Articulo.Single(m => m.ArticuloID == ArticuloID);
                        //CAMBIAMOS LA DESCRIPCIÓN POR LA QUE INGRESÓ EL USUARIO EN LA VISTA
                        articulo.Descripcion = Descripcion;
                        articulo.UltAct=DateTime.Now;
                        articulo.PrecioCosto = PrecioCosto;
                        articulo.PorcentajeGanancia = PorcentajeGanancia;
                        articulo.PrecioVenta = PrecioVenta;
                        articulo.SubrubroID = SubRubroID;
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


        public JsonResult BuscarArticulo(int ArticuloID)
        {
            //CREAMOS EL OBJETO BUSCADO CON EL PARAMETRO ENVIADO
            var articulo = _context.Articulo.Include(s => s.Subrubro).Include(t=>t.Subrubro.Rubro).Single(m => m.ArticuloID == ArticuloID);

            //CREAMOS UNA OBJETO LIST EN BLANCO DONDE INCLUYA SUBRUBROS
            //var articulo = _context.Articulo.Include(s => s.Subrubro).Include(t => t.Subrubro.Rubro).ToList();

            var articulomostrar = new ArticuloMostrar()
            {
                //HAY QUE PASAR SI O SI TODOS LOS PARAMETROS PARA QUE SE ARME EL OBJETO A MOSTRAR Y PODAMOS HACER
                //LAS VERIFICACIONES CORRESPONDIENTES EN LA VISTA 
                ArticuloID = articulo.ArticuloID,
                Descripcion = articulo.Descripcion,
                UltAct = articulo.UltAct,
                UltActString = articulo.UltAct.ToString("dd/MM/yyyy"),
                PrecioCosto = articulo.PrecioCosto,
                PorcentajeGanancia = articulo.PorcentajeGanancia,
                PrecioVenta = articulo.PrecioVenta,
                SubrubroID = articulo.SubrubroID,
                SubRubroNombre = articulo.Subrubro.Descripcion,
                RubroID = articulo.Subrubro.RubroID,
                //ESTE ES EL PARAMETRO QUE FALTABA PARA PODER BORRAR
                Eliminado = articulo.Eliminado,

            };

            return Json(articulomostrar);
        }

        public JsonResult DesactivarActivarArticulo(int ArticuloID, int Elimina)
        {
            bool resultado = true;
            //BUSCANDO EN TABLA EL ELEMENTEO CON ID 
            var articulo = _context.Articulo.Find(ArticuloID);
            if (articulo != null)
            {
                if (Elimina == 0)
                {
                    articulo.Eliminado = false;
                }
                else
                {
                    articulo.Eliminado = true;
                }

                _context.SaveChanges();
            }

            return Json(resultado);
        }

        private bool ArticuloExists(int id)
        {
            return _context.Articulo.Any(e => e.ArticuloID == id);
        }

    }
}
