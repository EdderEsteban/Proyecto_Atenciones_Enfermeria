using Microsoft.AspNetCore.Mvc;
using Proyecto_Atenciones_Enfermeria.Models;
using Proyecto_Atenciones_Enfermeria.Repositorios;

namespace Proyecto_Atenciones_Enfermeria.Controllers
{
    public class PrestacionController : Controller
    {
        [FromServices]
        public IGenericRepository<Prestacion> Repositorio { get; set; }

        [FromServices]
        public IGenericRepository<TipoPrestacion> RepositorioTiposPrestaciones { get; set; }

        // Método para listar las Prestaciones
        [HttpGet]
        public async Task<IActionResult> ListadoPrestacion()
        {
            try
            {
                var prestaciones = await Repositorio.GetAllAsync();
                var tiposPrestaciones = await RepositorioTiposPrestaciones.GetAllAsync(); // Obtén la lista de tipos de prestaciones
                ViewBag.TiposPrestaciones = tiposPrestaciones;
                return View(prestaciones);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Ocurrio un error al obtener las prestaciones";
                return RedirectToAction("Error", "Home");  // Redirige a una página de error
            }
        }

        // Método para agregar una nueva Prestacion (vista)
        [HttpGet]
        public async Task<IActionResult> AgregarPrestacion()
        {
            var tiposPrestaciones = await RepositorioTiposPrestaciones.GetAllAsync(); // Obtén la lista de tipos de prestaciones
            ViewBag.TiposPrestaciones = tiposPrestaciones;
            return View();
        }

        // Método para guardar una nueva Prestacion
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NuevoPrestacion(Prestacion prestacion)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Datos inválidos. Por favor, revise los campos e intente nuevamente.";
                return View("AgregarPrestacion", prestacion);
            }

            try
            {
                await Repositorio.AddAsync(prestacion);
                TempData["SuccessMessage"] = "La prestacion se ha creado exitosamente.";
                return RedirectToAction("AgregarPrestacion");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Ocurrio un error al crear la prestacion.";
                return RedirectToAction("agregarPrestacion");  // Redirige a la vista de agregar en caso de error
            }

        }

        // Método para editar una Prestacion (vista)
        [HttpGet]
        public async Task<IActionResult> EditarPrestacion(int id)
        {
            try
            {
                var prestacion = await Repositorio.GetByIdAsync(id);
                if (prestacion == null)
                {
                    TempData["ErrorMessage"] = "La prestacion no existe.";
                    return RedirectToAction("ListadoPrestacion");
                }
                return View(prestacion);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Ocurrio un error al obtener los datos de la prestacion.";
                return RedirectToAction("ListadoPrestacion");
            }
        }

        // Método para actualizar una Prestacion
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ActualizarPrestacion(Prestacion prestacion)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Datos inválidos. Por favor, revise los campos e intente nuevamente.";
                return View("EditarPrestacion", prestacion);
            }

            try
            {
                await Repositorio.UpdateAsync(prestacion);
                TempData["SuccessMessage"] = "La prestacion se ha actualizado exitosamente.";
                return RedirectToAction("ListadoPrestacion");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Ocurrio un error al actualizar la prestacion.";
                return RedirectToAction("EditarPrestacion", new { id = prestacion.Id_prestacion });
            }
        }

        // Método para borrar una Prestacion (logico)
        public async Task<IActionResult> BorrarPrestacionLogico(int id)
        {
            try
            {
                await Repositorio.LogicalDeleteAsync(id);
                TempData["SuccessMessage"] = "La prestacion se ha eliminado exitosamente.";
                return RedirectToAction("ListadoPrestacion");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Ocurrio un error al eliminar la prestacion.";
                return RedirectToAction("ListadoPrestacion");
            }
        }

        // Método para borrar una Prestacion (fisico)
        public async Task<IActionResult> BorrarPrestacionFisico(int id)
        {
            try
            {
                await Repositorio.DeleteAsync(id);
                TempData["SuccessMessage"] = "La prestacion se ha eliminado exitosamente.";
                return RedirectToAction("ListadoPrestacion");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Ocurrio un error al eliminar la prestacion.";
                return RedirectToAction("ListadoPrestacion");
            }
        }
    }
}