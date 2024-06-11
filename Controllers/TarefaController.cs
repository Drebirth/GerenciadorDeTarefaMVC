using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using desafio_mvc_gerenciador_de_tarefas.Context;
using desafio_mvc_gerenciador_de_tarefas.Models;
using Microsoft.AspNetCore.Mvc;

namespace desafio_mvc_gerenciador_de_tarefas.Controllers
{
    public class TarefaController : Controller
    {
        private readonly GerenciadorDeTarefaContext _context;
        public TarefaController(GerenciadorDeTarefaContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var contatos = _context.Tarefas.ToList();
            return View(contatos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(Tarefa tarefa)
        {
            if(ModelState.IsValid)
            {
                _context.Tarefas.Add(tarefa);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(tarefa);
        }
    }
}