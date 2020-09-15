using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EducationApi.Domain.DTOs;
using EducationApi.Domain.Entities;

namespace EducationApi.Domain.Contracts.DomainServices.Interfaces
{
    public interface IDomainServiceEscola : IDomainServiceBase<Escola, int>
    {
        Task SaveEscola(EscolaDTO escolaDTO);
        Task<Escola> GetEscolaById(int id);
        Task<IList<Escola>> GetEscolaByNome(string nome);
        Task<IList<Escola>> GetAllEscolas();
        Task UpdateEscola(EscolaUpdateDTO escolaDTO);
    }
}
