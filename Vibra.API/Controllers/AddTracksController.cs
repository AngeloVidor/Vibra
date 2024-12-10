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
        [HttpGet("artist/tracks")]
        public async Task<IActionResult> GetArtistTracksAsync()
        {

            try
            {
                var artistId = GetUserIdFromContext();
                var response = await _addTrackService.GetArtistTracksAsync(artistId);

                if (response == null || !response.Any())
                {
                    return NotFound($"No tracks found for artist with ID {artistId}.");
                }

                return Ok(response);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
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
