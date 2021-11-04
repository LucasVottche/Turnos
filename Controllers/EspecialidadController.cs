using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Turnos.Models;

namespace Turnos.Controllers
{
    public class EspecialidadController : Controller
    {
        private readonly TurnosContext _context;
        public EspecialidadController(TurnosContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Especialidad.ToList());
        }

        public IActionResult Edit(int? id) //este parametro podemos recibir null colocando el: ? 
        {
            if (id == null)
            {
                return NotFound();
            }

            {
                var especialidad = _context.Especialidad.Find(id);  //Find es lo mismo que select from where
                                                                    //nos retornara la especialidad que estamos buscando
                if (especialidad == null)
                {
                    return NotFound();  // es posible que recibamos el parametro id pero no exista en la base de datos y nos de un objeto nulo
                }
                return View(especialidad);

            }
        }
        [HttpPost]
        //estamos recibiendo los campos de idEspecilidad y descripcion
        public IActionResult Edit(int id, [Bind("idEspecialidad, Descripcion")] Especialidad especialidad)
        {
            if (id != especialidad.idEspecialidad)
            {
                return NotFound();
            }
            if (ModelState.IsValid) // si da false nos returna la vista 
            {
                _context.Update(especialidad);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));  //redirigirnos a la vista general de listado especialidades
            }
            return View(especialidad);
        }
      
    }
}