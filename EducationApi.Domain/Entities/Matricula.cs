using System;
namespace EducationApi.Domain.Entities
{
    public class Matricula
    {
        public virtual int Id { get; set; }
        public virtual Aluno Aluno { get; set; }
        public virtual Turma Turma { get; set; }
    }
}
