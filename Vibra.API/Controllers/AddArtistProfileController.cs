using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vibra.BLL.DTOs;
using Vibra.BLL.Interfaces.ArtistUser;

namespace Vibra.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddArtistProfileController : ControllerBase
    {
        private readonly IAddArtistProfileService _addArtistProfileService;
        public AddArtistProfileController(IAddArtistProfileService addArtistProfileService)
        {
            _addArtistProfileService = addArtistProfileService;
        }

        [HttpPost("Add-ArtistProfile")]
        public async Task<IActionResult> AddArtistProfile([FromBody] AddArtistProfileDto addArtistProfileDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var artistDto = await _addArtistProfileService.AddArtistProfileAsync(addArtistProfileDto);
                return Ok(artistDto);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}