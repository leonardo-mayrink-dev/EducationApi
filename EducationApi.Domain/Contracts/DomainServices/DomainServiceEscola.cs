using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EducationApi.Domain.Contracts.DomainServices.Interfaces;
using EducationApi.Domain.Contracts.Repositories;
using EducationApi.Domain.DTOs;
using EducationApi.Domain.Entities;

namespace EducationApi.Domain.Contracts.DomainServices
{
    public class DomainServiceEscola : DomainServiceBase<Escola, int>, IDomainServiceEscola
    {
        private readonly IRepositoryEscola repositoryEscola;

        public DomainServiceEscola(IRepositoryEscola repositoryEscola) : base(repositoryEscola)
        {
            this.repositoryEscola = repositoryEscola;
        }

        public async Task<IList<Escola>> GetAllEscolas()
        {
            return await repositoryEscola.FindAll();
        }

        public async Task<Escola> GetEscolaById(int id)
        {
            return await repositoryEscola.FindById(id);
        }

        public async Task<IList<Escola>> GetEscolaByNome(string nome)
        {
            return await repositoryEscola.FindByFilter(x => x.NomeEscola == nome);
        }

        public async Task SaveEscola(EscolaDTO escolaDTO)
        {

            try
            {

                Escola escola = new Escola
                {
                    NomeEscola = escolaDTO.NomeEscola,
                    Cnpj = escolaDTO.Cnpj,
                    Endereco = escolaDTO.Endereco,
                    Telefone = escolaDTO.Telefone
                };

                await repositoryEscola.SaveOrUpdate(escola);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateEscola(EscolaUpdateDTO escolaDTO)
        {
            Escola escola;

            try
            {
                escola = await repositoryEscola.FindById(escolaDTO.IdEscola);

                if (escola != null)
                {
                    escola.NomeEscola = escolaDTO.NomeEscola;
                    escola.Cnpj = escolaDTO.Cnpj;
                    escola.Endereco = escolaDTO.Endereco;
                    escola.Telefone = escolaDTO.Telefone;

                    await repositoryEscola.SaveOrUpdate(escola);
                }
                else
                {
                    throw new Exception("A escola não foi encontrada");
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
