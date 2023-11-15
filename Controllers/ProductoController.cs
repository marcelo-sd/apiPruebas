using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using ApiPruebas.Models;
using Microsoft.AspNetCore.Cors;
using System;

namespace ApiPruebas.Controllers
{

    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {

        public readonly DbapiContext _dbapiContext;
        public ProductoController(DbapiContext _context)
        {
            _dbapiContext = _context;
        }
       

        [HttpGet]
        [Route("Lista")]
        public IActionResult Lista()
        {
            List<Producto> lista = new List<Producto>();
            try
            {
                lista = _dbapiContext.Productos.Include(c => c.oCategoria).ToList();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", respone =lista });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, respone = lista });

            }
        }

        [HttpGet]
        [Route("Obtener/{idProducto:int}")]
        public IActionResult Obtner(int idProducto)
        {
            Producto ? oProducto = _dbapiContext.Productos.Find(idProducto);
            if(oProducto == null)
            {
                return BadRequest("Producto no encontrado");
            }
            try
            {

                oProducto = _dbapiContext.Productos.Include(c => c.oCategoria).Where(p => p.Idproducto == idProducto).FirstOrDefault();
          

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", respone = oProducto });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, respone = oProducto });

            }
        }
        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] Producto objeto)
        {
            try
            {

                _dbapiContext.Productos.Add(objeto);
                _dbapiContext.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok"});


            }
            catch (Exception ex) {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message});


            }
        }
        [HttpPut]
        [Route("Editar")]
        public IActionResult Editar([FromBody] Producto objeto)
        {
            Producto oProducto = _dbapiContext.Productos.Find(objeto.Idproducto);
            if (oProducto == null)
            {
                return BadRequest("Producto no encontrado");
            }
            try
            {
                oProducto.CodiBarra= objeto.CodiBarra is null ? oProducto.CodiBarra:objeto.CodiBarra;
                oProducto.Descripcion = objeto.Descripcion is null ? oProducto.Descripcion : objeto.Descripcion;
                oProducto.Marca = objeto.Marca is null ? oProducto.Marca : objeto.Marca;
                oProducto.Idcategoria = objeto.Idcategoria is null ? oProducto.Idcategoria : objeto.Idcategoria;
                oProducto.Precio = objeto.Precio is null ? oProducto.Precio : objeto.Precio;



                _dbapiContext.Productos.Update(oProducto);
                _dbapiContext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });


            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });


            }
        }
        [HttpDelete]
        [Route("Eliminar/{idProducto:int}")]

        public IActionResult Eliminar(int IdProducto)
        {
            Producto oProducto = _dbapiContext.Productos.Find(IdProducto);
            if (oProducto == null)
            {
                return BadRequest("Producto no encontrado");
            }
            try
            {
               

                _dbapiContext.Productos.Remove(oProducto);
                _dbapiContext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });


            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });


            }

        }



    }
}
