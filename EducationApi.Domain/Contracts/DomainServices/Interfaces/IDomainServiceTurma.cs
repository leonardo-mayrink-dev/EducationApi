using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EducationApi.Domain.DTOs;
using EducationApi.Domain.Entities;

namespace EducationApi.Domain.Contracts.DomainServices.Interfaces
{
    public interface IDomainServiceTurma : IDomainServiceBase<Turma, int>
    {
        Task SaveTurma(TurmaDTO turma);
        Task<Turma> GetTurmaById(int id);
        Task<IList<Turma>> GetTurmaByNome(string nome);
        Task<IList<Turma>> GetAllTurmas();
        Task UpdateTurma(TurmaUpdateDTO turmaDTO);
    }
}
