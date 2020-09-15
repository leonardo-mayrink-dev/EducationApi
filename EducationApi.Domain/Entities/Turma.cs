using System;

namespace EducationApi.Domain.Entities
{
    public class Turma
    {
        public virtual int IdTurma { get; set; }
        public virtual string NomeTurma { get; set; }
        public virtual Escola Escola { get; set; }
        //public virtual List<Professor> Professores { get; set; }
        //public virtual List<Aluno> Alunos { get; set; }

    }
}
