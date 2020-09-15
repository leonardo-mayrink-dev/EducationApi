using System;
using EducationApi.Domain.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using EducationApi.Domain.Entities;

namespace EducationApi.Application.Contracts.Interfaces
{
    public interface IAppServiceTurma : IAppServiceBase<Turma, int>
    {
        Task SaveTurma(TurmaDTO turma);
        Task<Turma> GetTurmaById(int id);
        Task<IList<Turma>> GetTurmaByNome(string nome);
        Task<IList<Turma>> GetAllTurmas();
        Task UpdateTurma(TurmaUpdateDTO turmaUpdateDTO);
    }
}
