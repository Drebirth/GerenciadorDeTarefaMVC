using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using desafio_mvc_gerenciador_de_tarefas.Models;
using Microsoft.EntityFrameworkCore;

namespace desafio_mvc_gerenciador_de_tarefas.Context
{
    public class GerenciadorDeTarefaContext : DbContext
    {
        public GerenciadorDeTarefaContext(DbContextOptions<GerenciadorDeTarefaContext> options) : base(options)
        {

        }

        public DbSet<Tarefa> Tarefas {get; set;}
        
    }
}