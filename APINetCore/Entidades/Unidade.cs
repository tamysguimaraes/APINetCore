﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APINetCore.Entidades
{
    public class Unidade
    {
        protected Unidade() { }
        public Unidade(string nome, string endereco)
        {
            Nome = nome;
            Endereco = endereco;
            Alunos = new List<Aluno>();
            Professores = new List<Professor>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public List<Aluno> Alunos { get; set; }
        public List<Professor> Professores { get; set; }
    }
}
