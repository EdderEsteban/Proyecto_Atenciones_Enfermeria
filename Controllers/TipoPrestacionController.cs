using Microsoft.AspNetCore.Mvc;
using Proyecto_Atenciones_Enfermeria.Models;
using Proyecto_Atenciones_Enfermeria.Repositorios;

namespace Proyecto_Atenciones_Enfermeria.Controllers
{
    public class TipoPrestacionController : Controller
    {
        private readonly IGenericRepository<TipoPrestacion> _repositorio;

        // Inyectamos el repositorio a través del constructor
        public TipoPrestacionController(IGenericRepository<TipoPrestacion> repositorioParam)
        {
            _repositorio = repositorioParam;
        }

        // Método para listar los Tipos de prestaciones
        [HttpGet]
        public async Task<IActionResult> ListadoTipo()
        {
            try
            {
                var tipoPrestaciones = await _repositorio.GetAllAsync();
                return View(tipoPrestaciones);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Ocurrió un error al obtener los tipos de prestaciones.";
                return RedirectToAction("Error", "Home");  // Redirige a una página de error
            }
        }

        // Método para agregar un nuevo Tipo de prestación (vista)
        [HttpGet]
        public IActionResult AgregarTipo()
        {
            return View();
        }

        // Método para guardar un nuevo Tipo de prestación
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NuevoTipo(TipoPrestacion tipoPrestacion)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Datos inválidos. Por favor, revise los campos e intente nuevamente.";
                return View("AgregarTipo", tipoPrestacion);
            }

            try
            {
                await _repositorio.AddAsync(tipoPrestacion);
                TempData["SuccessMessage"] = "El tipo de prestación se ha creado exitosamente.";
                return RedirectToAction("AgregarTipo");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Ocurrió un error al crear el tipo de prestación.";
                return RedirectToAction("AgregarTipo");  // Redirige a la vista de agregar en caso de error
            }
        }

        // Método para editar un Tipo de prestación (vista)
        [HttpGet]
        public async Task<IActionResult> EditarTipo(int id)
        {
            try
            {
                var tipoPrestacion = await _repositorio.GetByIdAsync(id);
                Console.WriteLine($"Id de la prestacin {tipoPrestacion.Id_tipo_prestacion} {tipoPrestacion.Tipo_prestacion}");
                if (tipoPrestacion == null)
                {
                    TempData["ErrorMessage"] = "El tipo de prestación no se encontró.";
                    return RedirectToAction("ListadoTipo");
                }
                return View(tipoPrestacion);  // Pasa el modelo a la vista de edición
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Ocurrió un error al obtener los datos del tipo de prestación.";
                return RedirectToAction("ListadoTipo");
            }
        }

        // Método para actualizar un Tipo de prestación
        [HttpPost]
        [ValidateAntiForgeryToken]  // Asegura la validación CSRF
        public async Task<IActionResult> ActualizarTipo(TipoPrestacion tipoPrestacion)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Datos inválidos. Por favor, revise los campos e intente nuevamente.";
                return View("EditarTipo", tipoPrestacion);  // Devuelve a la vista de edición en caso de error
            }

            try
            {
                await _repositorio.UpdateAsync(tipoPrestacion);
                TempData["SuccessMessage"] = "El tipo de prestación se ha actualizado exitosamente.";
                return RedirectToAction("ListadoTipo");  // Redirige al listado en caso de éxito
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Ocurrió un error al actualizar el tipo de prestación.";
                return RedirectToAction("EditarTipo", new { id = tipoPrestacion.Id_tipo_prestacion });
            }
        }

        // Metodo para borrar un tipo de prestacion (logico)
        public async Task<IActionResult> BorrarTipoLogico(int id)
        {
            try
            {
                await _repositorio.LogicalDeleteAsync(id);
                TempData["SuccessMessage"] = "El tipo de prestación se ha eliminado exitosamente.";
                return RedirectToAction("ListadoTipo");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Ocur Com un error al eliminar el tipo de prestación.";
                return RedirectToAction("ListadoTipo");
            }
        }

        // Metodo para borrar un tipo de prestacion (fisico)
        public async Task<IActionResult> BorrarTipoFisico(int id)
        {
            try
            {
                await _repositorio.DeleteAsync(id);
                TempData["SuccessMessage"] = "El tipo de prestación se ha eliminado exitosamente.";
                return RedirectToAction("ListadoTipo");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Ocur Com un error al eliminar el tipo de prestación.";
                return RedirectToAction("ListadoTipo");
            }
        }
    }
}
