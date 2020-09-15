using System;
using EducationApi.Domain.Entities;

namespace EducationApi.Domain.Contracts.Repositories
{
    public interface IRepositoryProfessor : IRepositoryBase<Professor, int>
    {
    }
}
