using System;
using EducationApi.Domain.Entities;

namespace EducationApi.Application.Contracts.Interfaces
{
    public interface IAppServiceProfessor : IAppServiceBase<Professor, int>
    {
    }
}
