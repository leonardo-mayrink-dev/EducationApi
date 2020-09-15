using System;
namespace EducationApi.Domain.DTOs
{
    public class TurmaUpdateDTO
    {
        public int IdTurma { get; set; }
        public string NomeTurma { get; set; }
        public int IdEscola { get; set; }
    }
}
