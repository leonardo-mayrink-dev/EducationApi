using System;
using EducationApi.Application.Contracts.Interfaces;
using EducationApi.Domain.Contracts.DomainServices.Interfaces;
using EducationApi.Domain.Entities;

namespace EducationApi.Application.Contracts.Services
{
    public class AppServiceProfessor : AppServiceBase<Professor, int>, IAppServiceProfessor
    {
        private readonly IDomainServiceProfessor domainServiceProfessor;

        public AppServiceProfessor(IDomainServiceProfessor domainServiceProfessor) : base(domainServiceProfessor)
        {
            this.domainServiceProfessor = domainServiceProfessor;
        }
    }
}
