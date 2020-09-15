using System;
using System.Collections.Generic;

namespace EducationApi.Domain.Entities
{
    public class Escola
    {
        public virtual int IdEscola { get; set; }
        public virtual string NomeEscola { get; set; }
        public virtual string Cnpj { get; set; }
        public virtual string Telefone { get; set; }
        public virtual string Endereco { get; set; }
        public virtual IList<Turma> Turmas { get; set; }
    }
}
