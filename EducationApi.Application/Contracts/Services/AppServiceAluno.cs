using System;
using EducationApi.Application.Contracts.Interfaces;
using EducationApi.Domain.Contracts.DomainServices.Interfaces;
using EducationApi.Domain.Entities;

namespace EducationApi.Application.Contracts.Services
{
    public class AppServiceAluno : AppServiceBase<Aluno, int>, IAppServiceAluno
    {
        private readonly IDomainServiceAluno domainServiceAluno;

        public AppServiceAluno(IDomainServiceAluno domainServiceAluno) : base(domainServiceAluno)
        {
            this.domainServiceAluno = domainServiceAluno;
        }
    }
}
