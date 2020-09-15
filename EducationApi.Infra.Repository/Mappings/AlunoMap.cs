using System;
using EducationApi.Domain.Entities;
using FluentNHibernate.Mapping;

namespace EducationApi.Infra.Repository.Mappings
{
    public class AlunoMap : ClassMap<Aluno>
    {
        public AlunoMap()
        {
            Id(x => x.Id)
                .GeneratedBy.Increment();

            Map(x => x.Nome)
                .Not.Nullable();

            Map(x => x.Endereço)
                .Not.Nullable();

            Map(x => x.Telefone)
                .Not.Nullable();

            Map(x => x.DataNascimento)
                .Not.Nullable();
        }        
    }
}
