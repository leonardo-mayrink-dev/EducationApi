using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EducationApi.Domain.DTOs;
using EducationApi.Domain.Entities;

namespace EducationApi.Application.Contracts.Interfaces
{
    public interface IAppServiceEscola : IAppServiceBase<Escola, int>
    {
        Task SaveEscola(EscolaDTO escola);
        Task<Escola> GetEscolaById(int id);
        Task<IList<Escola>> GetEscolaByNome(string nome);
        Task<IList<Escola>> GetAllEscolas();
        Task UpdateEscola(EscolaUpdateDTO escolaUpdateDTO);
    }
}
