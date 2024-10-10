using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Atenciones_Enfermeria.Data;
using Proyecto_Atenciones_Enfermeria.Models;
using Proyecto_Atenciones_Enfermeria.Repositorios;

namespace Proyecto_Atenciones_Enfermeria.Controllers;

public class TipoPrestacionController : Controller
{
    private readonly IGenericRepository<TipoPrestacion> _repositorio;

    // Inyectamos el repositorio a través del constructor
    public TipoPrestacionController(IGenericRepository<TipoPrestacion> repositorioParam)
    {
        _repositorio = repositorioParam;
    }

    // Metodo para listar los Tipos de prestaciones
    public async Task<IActionResult> ListadoTipo()
    {
        // Recupera todos los Tipos de prestaciones
        var tipoPrestaciones = await _repositorio.GetAllAsync();
        return View(tipoPrestaciones);
    }

    // Metodo para agregar un nuevo Tipo de prestacion
    public IActionResult AgregarTipo()
    {
        return View();
    }

    // Metodo para guardar un nuevo Tipo de prestacion
    [HttpPost]
    [AutoValidateAntiforgeryToken]// investigar esto en el trabajo
    public async Task<IActionResult> NuevoTipo(TipoPrestacion tipoPrestacion)
    {
        await _repositorio.AddAsync(tipoPrestacion);
        return RedirectToAction("AgregarTipo");
    }

    // Metodo para editar un Tipo de prestacion
    public async Task<IActionResult> EditarTipo(int id)
    {
        var tipoPrestacion = await _repositorio.GetByIdAsync(id);
        return View(tipoPrestacion);
    }

    // Metodo para actualizar un Tipo de prestacion
    [HttpPost]
    public async Task<IActionResult> ActualizarTipo(TipoPrestacion tipoPrestacion)
    {
        await _repositorio.UpdateAsync(tipoPrestacion);
        return RedirectToAction("ListadoTipo");
    }
}
