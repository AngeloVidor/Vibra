using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vibra.BLL.DTOs;
using Vibra.BLL.Interfaces.ArtistUser;

namespace Vibra.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AddArtistProfileController : ControllerBase
    {
        private readonly IAddArtistProfileService _addArtistProfileService;

        public AddArtistProfileController(IAddArtistProfileService addArtistProfileService)
        {
            _addArtistProfileService = addArtistProfileService;
        }

        [HttpPost("Add-ArtistProfile")]
        public async Task<IActionResult> AddArtistProfile(
            [FromBody] AddArtistProfileDto addArtistProfileDto
        )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                addArtistProfileDto.UserId = GetUserIdFromContext();
                var artistDto = await _addArtistProfileService.AddArtistProfileAsync(
                    addArtistProfileDto
                );
                return Ok(artistDto);
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
