using System;
using EducationApi.Domain.Entities;
using FluentNHibernate.Mapping;

namespace EducationApi.Infra.Repository.Mappings
{
    public class EscolaMap : ClassMap<Escola>
    {
        public EscolaMap()
        {
            Id(x => x.IdEscola)
                .GeneratedBy.Increment();

            Map(x => x.NomeEscola)
                .Not.Nullable();

            Map(x => x.Cnpj)
                .Not.Nullable();

            Map(x => x.Endereco)
                .Not.Nullable();

            Map(x => x.Telefone)
                .Not.Nullable();
            
            HasMany(x => x.Turmas).Inverse().Cascade.All().LazyLoad();
        }
    }
}
