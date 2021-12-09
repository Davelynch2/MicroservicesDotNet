using System;
using System.Collections.Generic;
using AutoMapper;
using CommandsService.Data;
using CommandsService.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace CommandsService.Controllers
{
    [Route("api/c/[controller]")]
    [ApiController]
    public class PlatformsController: ControllerBase
    {
        private readonly ICommandRepo _repository;
        public IMapper _mapper { get; }

        public PlatformsController(ICommandRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlatformreadDto>> GetPlatforms()
        {
            Console.WriteLine("--> Getting Platforms form CommandsService");

            var platformsItems = _repository.GetAllPlatforms();

            return Ok(_mapper.Map<IEnumerable<PlatformreadDto>>(platformsItems));
        }
        
        [HttpPost]
        public ActionResult TestInboundConnection()
        {
            Console.WriteLine("--> Inbound POST # Command Service");

            return Ok("Inbound test ok from Platforms Controller");
        }
    }
}