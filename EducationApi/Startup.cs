using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using EducationApi.Domain.Contracts.Repositories;
using EducationApi.Infra.Repository.Repositories;
using EducationApi.Application.Contracts.Interfaces;
using EducationApi.Application.Contracts.Services;
using EducationApi.Domain.Contracts.DomainServices;
using EducationApi.Domain.Contracts.DomainServices.Interfaces;
using EducationApi.Domain.ViewModels;
using EducationApi.Domain.Entities;
using AutoMapper;

namespace EducationApi
{
    public class Startup
    {

        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.WithOrigins("http://localhost:5001",
                                        "http://localhost:4200"
                                        )
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowCredentials();
                });
            });

            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Turma, TurmaViewModel>().ForMember(dst => dst.IdEscola, obj => obj.MapFrom(src => src.Escola.IdEscola))
                                                      .ForMember(dst => dst.NomeEscola, obj => obj.MapFrom(src => src.Escola.NomeEscola));

                cfg.CreateMap<Escola, EscolaViewModel>().ForMember(dest => dest.TurmaViewModel, obj => obj.MapFrom(src => src.Turmas));

            });
            

            IMapper mapper = config.CreateMapper();

            services.AddSingleton(mapper);

            // Escola
            services.AddTransient<IAppServiceEscola, AppServiceEscola>();
            services.AddTransient<IDomainServiceEscola, DomainServiceEscola>();
            services.AddTransient<IRepositoryEscola, RepositoryEscola>();

            // Turma
            services.AddTransient<IAppServiceTurma, AppServiceTurma>();
            services.AddTransient<IDomainServiceTurma, DomainServiceTurma>();
            services.AddTransient<IRepositoryTurma, RepositoryTurma>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(MyAllowSpecificOrigins);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


        }
    }
}
