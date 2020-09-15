using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EducationApi.Application.Contracts.Interfaces;
using EducationApi.Domain.DTOs;
using EducationApi.Domain.Entities;
using EducationApi.Util;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using AutoMapper;
using EducationApi.Domain.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EducationApi.Controllers
{
    [Route("api/[controller]")]
    public class TurmaController : Controller
    {

        private readonly ILogger<TurmaController> logger;

        private readonly IAppServiceTurma appServiceTurma;

        IMapper mapper;

        public TurmaController(ILogger<TurmaController> logger,
            IAppServiceTurma appServiceTurma,
            IMapper mapper)
        {
            this.logger = logger;
            this.appServiceTurma = appServiceTurma;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("turmas")]
        public async Task<IActionResult> Get()
        {

            logger.LogInformation("C# HTTP GET 'Turma Controller' processed a request.");

            string response;

            try
            {

                IList<Turma> result = await appServiceTurma.GetAllTurmas();

                if (result != null && result.Count > 0)
                {
                    IList<TurmaViewModel> resultMapped = mapper.Map<IList<TurmaViewModel>>(result);

                    response = ObjectSerializerUtil.ObjectSerializerRest(resultMapped);
                }
                else
                {
                    throw new ApplicationException("Data not found");
                }
            }
            catch (ArgumentException ex)
            {
                return new BadRequestObjectResult(new
                {
                    Message = ex.Message
                });
            }
            catch (ApplicationException ex)
            {
                return new NotFoundObjectResult(new
                {
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {

                return new BadRequestObjectResult(new
                {
                    Message = "Error getting Data.",
                    Exception = ex.Message
                });
            }

            return new OkObjectResult($"{response}");
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            logger.LogInformation("C# HTTP GET 'Turma Controller' processed a request.");

            string response;

            try
            {
                Turma result = await appServiceTurma.GetTurmaById(id);

                if (result != null)
                {

                    response = ObjectSerializerUtil.ObjectSerializerRest(result);
                }
                else
                {
                    throw new ApplicationException("Data not found");
                }

            }
            catch (ArgumentException ex)
            {
                return new BadRequestObjectResult(new
                {
                    Message = ex.Message
                });
            }
            catch (ApplicationException ex)
            {
                return new NotFoundObjectResult(new
                {
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {

                return new BadRequestObjectResult(new
                {
                    Message = "Error getting Data.",
                    Exception = ex.Message
                });
            }

            return new OkObjectResult($"{response}");
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TurmaDTO reqTurmaDTO)
        {
            try
            {
                bool isValidStringFields = !reqTurmaDTO.GetType().GetProperties()
                                .Where(pi => pi.PropertyType == typeof(string))
                                .Select(pi => (string)pi.GetValue(reqTurmaDTO))
                                .Any(value => string.IsNullOrEmpty(value));

                if (isValidStringFields)
                {
                    await appServiceTurma.SaveTurma(reqTurmaDTO);
                }
                else
                {
                    throw new ArgumentException("Preencha todos os campos.");
                }

            }
            catch (ArgumentException ex)
            {
                return new BadRequestObjectResult(new
                {
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(new
                {
                    Message = "Error getting Data Inventory.",
                    Exception = ex.Message
                });
            }

            return new OkObjectResult($"Sucesso!");
        }


        // PUT api/values/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] TurmaUpdateDTO reqTurmaUpdateDTO)
        {
            try
            {
                bool isValidStringFields = !reqTurmaUpdateDTO.GetType().GetProperties()
                                .Where(pi => pi.PropertyType == typeof(string))
                                .Select(pi => (string)pi.GetValue(reqTurmaUpdateDTO))
                                .Any(value => string.IsNullOrEmpty(value));

                if (isValidStringFields)
                {
                    await appServiceTurma.UpdateTurma(reqTurmaUpdateDTO);
                }
                else
                {
                    throw new ArgumentException("Preencha todos os campos.");
                }

            }
            catch (ArgumentException ex)
            {
                return new BadRequestObjectResult(new
                {
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(new
                {
                    Message = "Error getting Data Inventory.",
                    Exception = ex.Message
                });
            }

            return new OkObjectResult($"Sucesso!");
        }

    }
}
