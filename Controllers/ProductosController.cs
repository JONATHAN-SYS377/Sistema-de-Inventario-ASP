using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sistema_de_Inventario_ASP.Datos;
using Sistema_de_Inventario_ASP.Models;

namespace Sistema_de_Inventario_ASP.Controllers
{
    public class ProductosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Productos
        public async Task<IActionResult> IndexActivos()
        {
            var applicationDbContext = _context.Productos
        .Where(p => p.EstadoID == 1) // Filtrar por EstadoID igual a 1
        .Include(p => p.Categoria)
        .Include(p => p.Estado);

            var productosInactivos = await applicationDbContext.ToListAsync();

            if (productosInactivos.Count == 0)
            {
                ViewBag.Mensaje = "No hay datos disponibles.";
                return View(); // Retornar la vista sin pasar la lista vacía
            }

            return View(productosInactivos);
        }
        // GET: Productos Inactivos
        public async Task<IActionResult> IndexInactivos()
        {
            var applicationDbContext = _context.Productos
        .Where(p => p.EstadoID == 2) // Filtrar por EstadoID igual a 2
        .Include(p => p.Categoria)
        .Include(p => p.Estado);

            var productosInactivos = await applicationDbContext.ToListAsync();

            if (productosInactivos.Count == 0)
            {
                ViewBag.Mensaje = "No hay datos disponibles.";
                return View(); // Retornar la vista sin pasar la lista vacía
            }

            return View(productosInactivos);
        }
        // GET: Productos/Detalles
        public async Task<IActionResult> Detalles(int? id)
        {
            if (id == null || _context.Productos == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos
                .Include(p => p.Categoria)
                .Include(p => p.Estado)
                .FirstOrDefaultAsync(m => m.IDCodigo == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // GET: Productos/Crear Producto
        public IActionResult CrearProducto()
        {
            ViewData["CategoriaID"] = new SelectList(_context.Categorias, "Id", "NombreCategoria");
            ViewData["EstadoID"] = new SelectList(_context.Estado, "Id", "NombreEstado");
            return View();
        }


        // POST: Productos/Crear Producto
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearProducto(Producto producto)
        {
            try
            {
                _context.Add(producto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(IndexActivos));

            }
            catch (Exception)
            {

                return View(producto);
            }
        }

        // GET: Productos/Editar
        public async Task<IActionResult> EditarProducto(int? id)
        {

            if (id == null || _context.Productos == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            ViewData["CategoriaID"] = new SelectList(_context.Categorias, "Id", "NombreCategoria", producto.CategoriaID);
            ViewData["EstadoID"] = new SelectList(_context.Estado, "Id", "NombreEstado", producto.EstadoID);
            return View(producto);
        }

        // POST: Productos/Editar

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditarProducto(int id, Producto producto)
        {
            try
            {
                if (id != producto.IDCodigo)
                {
                    return NotFound();
                }
                _context.Update(producto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(IndexActivos));
            }
            catch (Exception)
            {

                return View(producto);
            }
        }

        // GET: Productos/Eliminar Producto
        public async Task<IActionResult> EliminarProducto(int? id)
        {
            if (id == null || _context.Productos == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos
                .Include(p => p.Categoria)
                .Include(p => p.Estado)
                .FirstOrDefaultAsync(m => m.IDCodigo == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // POST: Productos/Eliminar Producto
        [HttpPost, ActionName("EliminarProducto")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Productos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Productos'  is null.");
            }
            var producto = await _context.Productos.FindAsync(id);
            if (producto != null)
            {
                _context.Productos.Remove(producto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(IndexActivos));
        }

        private bool ProductoExists(int id)
        {
          return (_context.Productos?.Any(e => e.IDCodigo == id)).GetValueOrDefault();
        }
    }
}
