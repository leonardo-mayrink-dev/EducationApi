using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EducationApi.Domain.Contracts.DomainServices.Interfaces;
using EducationApi.Domain.Contracts.Repositories;
using EducationApi.Domain.DTOs;
using EducationApi.Domain.Entities;
using System.Linq;

namespace EducationApi.Domain.Contracts.DomainServices
{
    public class DomainServiceTurma : DomainServiceBase<Turma, int>, IDomainServiceTurma
    {
        private readonly IRepositoryTurma repositoryTurma;
        private readonly IDomainServiceEscola domainServiceEscola;

        public DomainServiceTurma(IRepositoryTurma repositoryTurma,
                                  IDomainServiceEscola domainServiceEscola) : base(repositoryTurma)
        {
            this.repositoryTurma = repositoryTurma;
            this.domainServiceEscola = domainServiceEscola;
        }

        public async Task<IList<Turma>> GetAllTurmas()
        {
            return await repositoryTurma.FindAll();
        }

        public async Task<Turma> GetTurmaById(int id)
        {
            return await repositoryTurma.FindById(id);
        }

        public async Task<IList<Turma>> GetTurmaByNome(string nome)
        {
            return await repositoryTurma.FindByFilter(x => x.NomeTurma == nome);
        }

        public async Task SaveTurma(TurmaDTO turmaDTO)
        {
            Turma turma = null;
            try
            {
                IList<Escola> escola = await domainServiceEscola.GetEscolaByNome(turmaDTO.NomeEscola);

                if (escola != null && escola.Count() > 0)
                {
                    turma = new Turma
                    {
                        NomeTurma = turmaDTO.NomeTurma,
                        Escola = escola.FirstOrDefault()
                    };

                    await repositoryTurma.Save(turma);
                }
                else
                {
                    throw new Exception("A escola informada não foi encontrada para cadastrar esta turma.");
                }

                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateTurma(TurmaUpdateDTO turmaDTO)
        {
            Turma turma;

            try
            {

                turma = await repositoryTurma.FindById(turmaDTO.IdTurma);

                if(turma != null)
                {
                    turma.NomeTurma = turmaDTO.NomeTurma;

                    await repositoryTurma.Save(turma);
                }
                else
                {
                    throw new Exception("A turma informada não foi encontrada.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
