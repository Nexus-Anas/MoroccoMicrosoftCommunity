using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MMC.Core.Models;
using MMC.Core.Models.Dtos;
using MMC.Core.Services;

namespace MMC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpeakerInfoController : ControllerBase
    {
        private readonly  ISpeakerInfoService _speakerService;
        public SpeakerInfoController(ISpeakerInfoService service)
        {
            _speakerService = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SpeakerInfo>>> Get()
        {
            var speakers = await _speakerService.FindAll();
            return Ok(speakers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SpeakerInfo>> GetById(int id)
        {
            var speaker = await _speakerService.Find(id);

            if (speaker == null)
            {
                return NotFound();
            }

            return Ok(speaker);
        }


        [HttpPost]
        public async Task<ActionResult<SpeakerDto>> Create([FromBody] SpeakerDto speakerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newSpeaker = new SpeakerInfo
            {
                Phone = speakerDto.Phone,
                PhotoPath = speakerDto.PhotoPath,
                MCT = speakerDto.MCT,
                MVP = speakerDto.MVP,
                Biography = speakerDto.Biography,
                Message = speakerDto.Message,
                UserId = speakerDto.UserId,
                Facebook = speakerDto.Facebook,  
                Instagram = speakerDto.Instagram,
                Twitter = speakerDto.Twitter,
                Linkedin = speakerDto.Linkedin,
                Website = speakerDto.Website
            };


            await _speakerService.Create(newSpeaker);

            return Ok(newSpeaker);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] SpeakerDto speakerDto)
        {
            var existingSpeaker = await _speakerService.Find(id);

            if (existingSpeaker == null || id != existingSpeaker.Id)
            {
                return BadRequest();
            }

            existingSpeaker.Phone = speakerDto.Phone;
            existingSpeaker.PhotoPath = speakerDto.PhotoPath;
            existingSpeaker.MCT = speakerDto.MCT;
            existingSpeaker.MVP = speakerDto.MVP;
            existingSpeaker.Biography = speakerDto.Biography;
            existingSpeaker.Message = speakerDto.Message;
            existingSpeaker.UserId = speakerDto.UserId;


            await _speakerService.Update(id,existingSpeaker);

            return NoContent();
        }

    }
}
