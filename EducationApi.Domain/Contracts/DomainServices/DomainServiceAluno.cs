using System;
using EducationApi.Domain.Contracts.DomainServices.Interfaces;
using EducationApi.Domain.Contracts.Repositories;
using EducationApi.Domain.Entities;

namespace EducationApi.Domain.Contracts.DomainServices
{
    public class DomainServiceAluno : DomainServiceBase<Aluno, int>, IDomainServiceAluno
    {
        private readonly IRepositoryAluno repositoryAluno;

        public DomainServiceAluno(IRepositoryAluno repositoryAluno) : base(repositoryAluno)
        {
            this.repositoryAluno = repositoryAluno;
        }
    }
}
