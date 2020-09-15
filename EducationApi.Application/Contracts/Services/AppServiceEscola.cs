using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EducationApi.Application.Contracts.Interfaces;
using EducationApi.Domain.Contracts.DomainServices.Interfaces;
using EducationApi.Domain.DTOs;
using EducationApi.Domain.Entities;

namespace EducationApi.Application.Contracts.Services
{
    public class AppServiceEscola : AppServiceBase<Escola, int>, IAppServiceEscola
    {
        private readonly IDomainServiceEscola domainServiceEscola;

        public AppServiceEscola(IDomainServiceEscola domainServiceEscola) : base(domainServiceEscola)
        {
            this.domainServiceEscola = domainServiceEscola;
        }

        public async Task<IList<Escola>> GetAllEscolas()
        {
            return await domainServiceEscola.GetAllEscolas();
        }

        public async Task<Escola> GetEscolaById(int id)
        {
            return await domainServiceEscola.GetEscolaById(id);
        }

        public async Task<IList<Escola>> GetEscolaByNome(string nome)
        {
            return await domainServiceEscola.GetEscolaByNome(nome);
        }

        public async Task SaveEscola(EscolaDTO escolaDTO)
        {
            await domainServiceEscola.SaveEscola(escolaDTO);
        }

        public async Task UpdateEscola(EscolaUpdateDTO escolaUpdateDTO)
        {
            await domainServiceEscola.UpdateEscola(escolaUpdateDTO);
        }
    }
}
