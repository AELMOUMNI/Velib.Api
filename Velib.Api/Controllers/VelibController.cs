using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dtos = Velib.Api.Models;
using Velib.Core.Services;
using AutoMapper;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System;
using Velib.Api.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Velib.Api.Controllers
{
    [Route("api/velib")]
    [ApiController]
    public class VelibController : ControllerBase
    {
        private readonly IVelibService _velibService;
        private readonly IMapper _mapper;
        public VelibController(IVelibService velibService, IMapper mapper)
        {
            _velibService = velibService;
            _mapper = mapper;
        }

        /// <summary>
        /// Retourne la station avec le plus de borne disponible et le nombre de vélos disponible
        /// </summary>
        /// <returns>la station avec le plus de borne disponible et le nombre de vélos disponible</returns>
        /// <response code ="200">Réponse a la requete avec succès</response>
        /// <response code ="500">Erreur interne du serveur</response>
        [HttpGet]
        [Route("maxdocksavailable")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Dtos.Response<List<Dtos.VelibAvailableReelTimeResponse>>>> GetMaxDocksAvailablel()
        {
            Dtos.Response<List<Dtos.VelibAvailableReelTimeResponse>> response;
            try
            {
                var velibs = await _velibService.GetVelibs().ConfigureAwait(false);
                var count = velibs.Nhits;
                var allVelibs = await _velibService.GetAllVelibDisponibiliteEnTempsReel(count);
                var MaxOfDocksavailable = allVelibs.Records.Max(x => x.Fields.Numdocksavailable);

                var velibWithMaxDocksavailableService = allVelibs.Records.Where(x => x.Fields.Numdocksavailable == MaxOfDocksavailable).ToList();
                var velibWithMaxDocksavailable = _mapper.Map<List<Dtos.VelibAvailableReelTimeResponse>>(velibWithMaxDocksavailableService);
                
                response = new Dtos.Response<List<Dtos.VelibAvailableReelTimeResponse>>()
                {
                    Count = velibWithMaxDocksavailable.Count,
                    Data = velibWithMaxDocksavailable,
                    Status = StatusCodes.Status200OK
                };
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

            return Ok(response);
        }

        /// <summary>
        /// Retourne le nombre de stations qui ne fonctionnent pas avec la liste de nom des stations. 
        /// </summary>
        /// <returns>le nombre de stations qui ne fonctionnent pas avec la liste de nom des stations</returns>
        /// <response code ="200">Réponse a la requete avec succès</response>
        /// <response code ="500">Erreur interne du serveur</response>
        [HttpGet]
        [Route("notworkingstation")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(Dtos.Response<List<Dtos.VelibAvailableReelTimeResponse>>), Description = "Retourne le nombre de stations qui ne fonctionnent pas avec la liste de nom des stations.")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Dtos.Response<List<Dtos.VelibAvailableReelTimeResponse>>>> GetNotWorkingStation()
        {
            Dtos.Response<List<Dtos.VelibAvailableReelTimeResponse>> response;
            try
            {
                var velibs = await _velibService.GetVelibs().ConfigureAwait(false);
                var count = velibs.Nhits;
                var allVelibs = await _velibService.GetAllVelibDisponibiliteEnTempsReel(count);

                var velibWithNotWorkingStattionService = allVelibs.Records.Where(x => x.Fields.IsInstalled == nameof(StationStatus.NON)).ToList();
                var velibWithNotWorkingStattion = _mapper.Map<List<Dtos.VelibAvailableReelTimeResponse>>(velibWithNotWorkingStattionService);

                response = new Dtos.Response<List<Dtos.VelibAvailableReelTimeResponse>>()
                {
                    Count = velibWithNotWorkingStattion.Count,
                    Data = velibWithNotWorkingStattion,
                    Status = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

            return Ok(response);
        }
    }
}
