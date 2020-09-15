using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EducationApi.Application.Contracts.Interfaces;
using EducationApi.Domain.Contracts.DomainServices.Interfaces;
using EducationApi.Domain.DTOs;
using EducationApi.Domain.Entities;

namespace EducationApi.Application.Contracts.Services
{
    public class AppServiceTurma : AppServiceBase<Turma, int>, IAppServiceTurma
    {
        private readonly IDomainServiceTurma domainServiceTurma;

        public AppServiceTurma(IDomainServiceTurma domainServiceTurma) : base(domainServiceTurma)
        {
            this.domainServiceTurma = domainServiceTurma;
        }

        public async Task<IList<Turma>> GetAllTurmas()
        {
            return await domainServiceTurma.GetAllTurmas();
        }

        public async Task<Turma> GetTurmaById(int id)
        {
            return await domainServiceTurma.GetTurmaById(id); 
        }

        public async Task<IList<Turma>> GetTurmaByNome(string nome)
        {
            return await domainServiceTurma.GetTurmaByNome(nome);
        }

        public async Task SaveTurma(TurmaDTO turmaDTO)
        {
            await domainServiceTurma.SaveTurma(turmaDTO);
        }

        public async Task UpdateTurma(TurmaUpdateDTO turmaUpdateDTO)
        {
            await domainServiceTurma.UpdateTurma(turmaUpdateDTO);
        }
    }
}
