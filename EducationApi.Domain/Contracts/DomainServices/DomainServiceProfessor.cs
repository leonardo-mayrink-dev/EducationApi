using System;
using EducationApi.Domain.Contracts.DomainServices.Interfaces;
using EducationApi.Domain.Contracts.Repositories;
using EducationApi.Domain.Entities;

namespace EducationApi.Domain.Contracts.DomainServices
{
    public class DomainServiceProfessor : DomainServiceBase<Professor, int>, IDomainServiceProfessor
    {
        private readonly IRepositoryProfessor repositoryProfessor;

        public DomainServiceProfessor(IRepositoryProfessor repositoryProfessor) : base(repositoryProfessor)
        {
            this.repositoryProfessor = repositoryProfessor;
        }
    }
}
