using MediaHub.Application.DTOs;
using MediaHub.Application.Interfaces;
using MediaHub.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediaHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediaController : ControllerBase
    {
        private readonly IMediaService _mediaService;
        public MediaController(IMediaService mediaService)
        {
                _mediaService = mediaService;   
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateMedia([FromBody] CreateMediaDto model)
        {
            var media = new Media
            {
                Title = model.Title,
                Description = model.Description,
                FilePath = model.FilePath,
                MediaType = model.MediaType,
                UserId = model.UserId,
                CategoryId = model.CategoryId
            };
            var result = await _mediaService.CreateMedia(media);
            if (result.IsSuccess)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public async Task<IActionResult> DeleteMedia([FromQuery] long id)
        {
            var result = await _mediaService.DeleteMedia(id);
            if (result.IsSuccess)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("getall")] 
        public async Task<IActionResult> GetAllMedia()
        {
            var result = await _mediaService.GetAllMedia();
            if (result.IsSuccess)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public async Task<IActionResult> GetMediaById([FromQuery] long id)
        {
            var result = await _mediaService.ReadMedia(id);
            if (result.IsSuccess)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdateMedia([FromBody] Domain.Entities.Media model)
        {
            var result = await _mediaService.UpdateMedia(model);
            if (result.IsSuccess)
                return Ok(result);
            return BadRequest(result);
        }
    }
}
