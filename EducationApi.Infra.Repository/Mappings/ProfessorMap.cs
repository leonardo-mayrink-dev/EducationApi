using System;
using EducationApi.Domain.Entities;
using FluentNHibernate.Mapping;

namespace EducationApi.Infra.Repository.Mappings
{
    public class ProfessorMap : ClassMap<Professor>
    {
        public ProfessorMap()
        {
            Id(x => x.Id)
               .GeneratedBy.Increment();

            Map(x => x.Nome)
                .Not.Nullable();

            Map(x => x.Endereco)
                .Not.Nullable();

            Map(x => x.Cpf)
                .Not.Nullable();

            Map(x => x.Email)
                .Not.Nullable();
        }
    }
}
