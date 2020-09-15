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
    [ApiController]
    [Route("api/[controller]")]
    public class EscolaController : ControllerBase
    {
        private readonly ILogger<EscolaController> logger;

        private readonly IAppServiceEscola appServiceEscola;

        IMapper mapper;

        public EscolaController(ILogger<EscolaController> logger,
                                IAppServiceEscola appServiceEscola,
                                IMapper mapper)
        {
            this.logger = logger;
            this.appServiceEscola = appServiceEscola;
            this.mapper = mapper;
        }


        [HttpGet]
        [Route("escolas")]
        public async Task<IActionResult> Get()
        {

            logger.LogInformation("C# HTTP GET 'Escola Controller' processed a request.");

            string response;

            try
            {                
                IList<Escola> result = await appServiceEscola.GetAllEscolas();                                         

                if (result != null && result.Count > 0)
                {
                    IList<EscolaViewModel> resultMapped = mapper.Map<IList<EscolaViewModel>>(result);

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

        // GET: api/values
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            logger.LogInformation("C# HTTP GET 'Escola Controller' processed a request.");

            string response;

            try
            {
                Escola result = await appServiceEscola.GetEscolaById(id);

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
        public async Task<IActionResult> Post([FromBody] EscolaDTO reqEscolaDTO)
        {
            try
            {
                bool isValidStringFields = !reqEscolaDTO.GetType().GetProperties()
                                .Where(pi => pi.PropertyType == typeof(string))
                                .Select(pi => (string)pi.GetValue(reqEscolaDTO))
                                .Any(value => string.IsNullOrEmpty(value))
                                
                                ;

                if (isValidStringFields)
                {                    
                    await appServiceEscola.SaveEscola(reqEscolaDTO);
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

            //return new OkObjectResult($"{}");
            return new OkObjectResult($"Sucesso!");
        }

        

   
        // PUT api/values/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] EscolaUpdateDTO reqEscolaUpdateDTO)
        {
            try
            {
                bool isValidStringFields = !reqEscolaUpdateDTO.GetType().GetProperties()
                                .Where(pi => pi.PropertyType == typeof(string))
                                .Select(pi => (string)pi.GetValue(reqEscolaUpdateDTO))
                                .Any(value => string.IsNullOrEmpty(value))

                                ;

                if (isValidStringFields)
                {
                    await appServiceEscola.UpdateEscola(reqEscolaUpdateDTO);
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

            //return new OkObjectResult($"{}");
            return new OkObjectResult($"Sucesso!");
        }

    }
}
