using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PORTPROJECTWEBAPI.Models;
using PORTPROJECTWEBAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace PORTPROJECTWEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortController : ControllerBase
    {
        private readonly IPortRepository _portRepository;
        public PortController(IPortRepository portRepository)
        {
            _portRepository = portRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllAvlSlots()
        {
            var slots = await _portRepository.GetAvalSlotsAsync();
            return Ok(slots);
        }
        [HttpPost("")]
        public async Task<IActionResult> AddUser([FromBody] UserClass userModel)
        {
            var user = await _portRepository.AddUserAsync(userModel);
            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSlot([FromBody] SlotClass slotsModel, [FromRoute] int id)
        {
            await _portRepository.UpdateSlot(id, slotsModel);
            return Ok();
        }



    }
}
