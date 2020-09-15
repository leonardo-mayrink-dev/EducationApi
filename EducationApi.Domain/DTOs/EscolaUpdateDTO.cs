using System;
namespace EducationApi.Domain.DTOs
{
    public class EscolaUpdateDTO
    {
        public int IdEscola { get; set; }
        public string NomeEscola { get; set; }
        public string Cnpj { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }

    }
}
