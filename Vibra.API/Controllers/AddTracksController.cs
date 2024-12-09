using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vibra.BLL.DTOs;
using Vibra.BLL.Interfaces.Tracks;

namespace Vibra.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddTracksController : ControllerBase
    {
        private readonly IAddTrackService _addTrackService;

        public AddTracksController(IAddTrackService addTrackService)
        {
            _addTrackService = addTrackService;
        }

        [HttpPost("add-Track")]
        public async Task<IActionResult> AddTrackAsync([FromBody] AddTrackDto addTrackDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            addTrackDto.ArtistId = GetUserIdFromContext();

            try
            {
                var addedTrack = await _addTrackService.AddTrackAsync(addTrackDto);
                return Ok(addedTrack);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        private int GetUserIdFromContext()
        {
            if (
                HttpContext.Items["userId"] is not string userId
                || !int.TryParse(userId, out var id)
            )
            {
                throw new UnauthorizedAccessException("Invalid or missing user ID.");
            }
            return id;
        }
    }
}
