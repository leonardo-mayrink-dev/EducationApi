using System;
using EducationApi.Domain.Entities;
using FluentNHibernate.Mapping;

namespace EducationApi.Infra.Repository.Mappings
{
    public class TurmaMap : ClassMap<Turma>
    {
        public TurmaMap()
        {
            Id(x => x.IdTurma)
               .GeneratedBy.Increment();

            Map(x => x.NomeTurma)
                .Not.Nullable();

            References(x => x.Escola).Cascade.None(); 

        }
    }
}
