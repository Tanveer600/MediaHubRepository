using MediaHub.Application.DTOs;
using MediaHub.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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

        // ✅ CREATE
        [HttpPost("create")]
        public async Task<IActionResult> CreateMedia([FromBody] CreateMediaDto dto)
        {
            var result = await _mediaService.CreateMedia(dto);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        // ✅ DELETE
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteMedia([FromQuery] long id)
        {
            var result = await _mediaService.DeleteMedia(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        // ✅ GET ALL
        [HttpGet("getall")]
        public async Task<IActionResult> GetAllMedia()
        {
            var result = await _mediaService.GetAllMedia();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        // ✅ GET BY ID
        [HttpGet("getbyid")]
        public async Task<IActionResult> GetMediaById([FromQuery] long id)
        {
            var result = await _mediaService.ReadMedia(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        // ✅ UPDATE
        [HttpPut("update")]
        public async Task<IActionResult> UpdateMedia([FromBody] UpdateMediaDto dto)
        {
            var result = await _mediaService.UpdateMedia(dto);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
