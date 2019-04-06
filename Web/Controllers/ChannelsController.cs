using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaAds.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChannelsController : ControllerBase
    {
        private readonly IChannelRepository _channelRepository;

        public ChannelsController(IChannelRepository repository) => _channelRepository = repository;


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var channels = await _channelRepository.GetAllAsync();
            return Ok(channels);
        }

        [HttpGet, Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var channel = await _channelRepository.GetByIdAsync(id);
            return Ok(channel);
        }

        //[HttpGet]
        //public async Task<IActionResult> GetByCategory(int category)
        //{
        //    var channels = await _channelRepository.
        //    return Ok(channels);
        //}
    }
}