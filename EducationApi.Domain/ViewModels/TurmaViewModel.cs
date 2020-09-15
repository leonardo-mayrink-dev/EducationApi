using System;

namespace EducationApi.Domain.ViewModels
{
    public class TurmaViewModel
    {
        public virtual int IdTurma { get; set; }
        public virtual string NomeTurma { get; set; }
        public virtual string NomeEscola { get; set; }
        public virtual int IdEscola { get; set; }
    }
}
