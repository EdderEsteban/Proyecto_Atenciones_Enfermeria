using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Atenciones_Enfermeria.Models;
using Proyecto_Atenciones_Enfermeria.Data;

namespace Proyecto_Atenciones_Enfermeria.Controllers;

public class TipoPrestacionController : Controller
{
    private readonly DataContext context;

    public TipoPrestacionController(DataContext context)
    {
        this.context = context;
    }

    public IActionResult ListadoTipo()
    {
        return View();
    }

}