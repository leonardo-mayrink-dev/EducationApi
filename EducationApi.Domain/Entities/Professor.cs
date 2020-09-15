using System;
namespace EducationApi.Domain.Entities
{
    public class Professor
    {
        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Endereco { get; set; }
        public virtual string Cpf { get; set; }
        public virtual string Email { get; set; }
    }
}
