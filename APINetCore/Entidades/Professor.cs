﻿using APINetCore.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APINetCore.Entidades
{
    public class Professor
    {
        protected Professor() { }
        public Professor(string nome, string endereco, int idUnidade)
        {
            Nome = nome;
            Endereco = endereco;
            Status = StatusProfessorEnum.Ativo;
            Alunos = new List<Aluno>();
            IdUnidade = idUnidade;
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Endereco { get; private set; }
        public StatusProfessorEnum Status { get; private set; }
        public List<Aluno> Alunos { get; private set; }

        public int IdUnidade { get; private set; }
        public Unidade Unidade { get; private set; }
    }
}
