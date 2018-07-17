using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SampleAspNetCore.Models;
using SampleClassLibrary.NetStandard;
using SampleClassLibrary.NetStandard.Model;

namespace SampleAspNetCore.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class EmailQueueController : Controller
    {
        private readonly IEmailDataAccess _emailDataAccess;

        public EmailQueueController(IEmailDataAccess emailDataAccess)
        {
            _emailDataAccess = emailDataAccess;
        }

        // POST: api/EmailQueue
        [HttpPost]
        public IActionResult Post([FromBody] EmailDTO emaildataDto)
        {
            var email = Mapper.Map<AutomatedEmails>(emaildataDto);
            var getData = _emailDataAccess.Insert(email);
            var response = Mapper.Map<EmailDTO>(getData);
            return Created($"/api/Email/{response.EmailId}", response);
        }

        // GET: api/EmailQueue/All
        [HttpGet("All")]
        public IActionResult Get()
        {
            var getData = _emailDataAccess.Get();
            var response = Mapper.Map<List<EmailDTO>>(getData);
            return Ok(response);
        }

        // GET: api/EmailQueue/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var getData = _emailDataAccess.Get(id);
                var response = Mapper.Map<EmailDTO>(getData);
                return Ok(response);
            }
            catch (Exception e) when (e.Message == "Error getting AutomatedEmail record.")
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Unknow Failure: {ex.Message}");
            }
        }

        // GET: api/EmailQueue/SentQueue/true
        [HttpGet("SentQueue/{sent}")]
        public IActionResult SentQueue(string sent)
        {
            var getData = _emailDataAccess.Get(sent == "true");
            var response = Mapper.Map<List<EmailDTO>>(getData);
            return Ok(response);
        }
    }
}