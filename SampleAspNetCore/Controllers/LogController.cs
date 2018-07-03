using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SampleAspNetCore.Models;
using SampleClassLibrary.NetStandard;
using SampleClassLibrary.NetStandard.Model;

namespace SampleAspNetCore.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class LogController : Controller
    {
        private readonly ILogInformationDataAccess _logInformationDataAccess;

        public LogController(ILogInformationDataAccess logInformationDataAccess)
        {
            _logInformationDataAccess = logInformationDataAccess;
        }
        // GET: api/Log
        [HttpGet]
        public IActionResult Get()
        {
            var logList = _logInformationDataAccess.Get().ToList();
            var response = Mapper.Map<List<LogInformationDTO>>(logList);
            return Ok(response);
        }

        // GET: api/Log/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var getData = _logInformationDataAccess.Get(id);
                var response = Mapper.Map<LogInformationDTO>(getData);
                return Ok(response);
            }
            catch (Exception e) when (e.Message == "Error getting LogInformation record.")
            {
                return NotFound();
            }
            catch (Exception e)
            {
                return StatusCode(500, "Unknow Failure: Logged");
            }

        }

        // POST: api/Log
        [HttpPost]
        public IActionResult Post([FromBody] LogInformationDTO logdataDto)
        {
            var log = Mapper.Map<LogInformation>(logdataDto);
            var getData = _logInformationDataAccess.Insert(log);
            var response = Mapper.Map<LogInformationDTO>(getData);
            return Created($"/api/Log/{response.LogId}", response);

        }
    }
}
