using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace desafio_mvc_gerenciador_de_tarefas.Models
{
    public class Tarefa
    {
        public int Id { get; set; }	
        public string Titulo { get; set; }

        public string Descricao { get; set; }
        
        public DateTime DataInclusao { get; set; }

        public DateTime DataLimite { get; set; }
        
        public bool Concluido { get; set; }
    }
}