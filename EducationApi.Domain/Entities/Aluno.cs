using System;
namespace EducationApi.Domain.Entities
{
    public class Aluno
    {
        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Telefone { get; set; }
        public virtual string Endereço { get; set; }
        public virtual DateTime DataNascimento { get; set; }
    }
}
