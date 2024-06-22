using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using desafio_mvc_gerenciador_de_tarefas.Context;
using desafio_mvc_gerenciador_de_tarefas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
            // if(ModelState.IsValid)
            // {//validacao de data
            //    if(tarefa.DataInclusao > tarefa.DataLimite)
            //     {
            //     ModelState.AddModelError("DataLimite"," A data Limite não pode ser superior que a data de inclusão");
            //     return View(tarefa);//retorna para a mesma pagina para que seja feita a correção antes da inclusao.
            //     } 
            // }else{
            //     _context.Tarefas.Add(tarefa);
            //     _context.SaveChanges();
            //     return RedirectToAction(nameof(Index));
            // }
            if(tarefa.DataInclusao > tarefa.DataLimite)
            {
                ModelState.AddModelError("DataLimite"," A data Limite não pode ser superior que a data de inclusão");
                return View(tarefa);
            }
            if(ModelState.IsValid)
            {
                _context.Tarefas.Add(tarefa);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
            
        }

        public IActionResult Editar(int id)
        {
            var tarefa = _context.Tarefas.Find(id);

            if(tarefa == null )
            {
                return NotFound();
            }

            return View(tarefa);
        }

        [HttpPost]
        public IActionResult Editar(Tarefa tarefa)
        {
            var tarefaBanco = _context.Tarefas.Find(tarefa.Id);

            tarefaBanco.Titulo = tarefa.Titulo;
            tarefaBanco.Descricao = tarefa.Descricao;
            tarefaBanco.Concluido = tarefa.Concluido;

            _context.Tarefas.Update(tarefaBanco);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));

        }

        public IActionResult Detalhes(int id)
        {
            var tarefa = _context.Tarefas.Find(id);

            if(tarefa == null)
                return RedirectToAction(nameof(Index));
            
            return View(tarefa);
        }

        public IActionResult Deletar(int id)
        {
            var tarefa = _context.Tarefas.Find(id);

            if(tarefa == null)
                return RedirectToAction(nameof(Index));

            return View(tarefa);

        }

        [HttpPost]
        public IActionResult Deletar(Tarefa tarefa)
        {
            var tarefaBanco = _context.Tarefas.Find(tarefa.Id);

            _context.Tarefas.Remove(tarefaBanco);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}