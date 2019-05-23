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

        [HttpGet, Route("categories")]
        public async Task<IActionResult> Categories()
        {
            var categories = await _channelRepository.GetCategories();
            return Ok(categories);
        }

        [HttpGet, Route("category/{id}")]
        public async Task<IActionResult> GetByCategory(int id)
        {
            var channels = await _channelRepository.GetByCategory(id);
            return Ok(channels);
        }
    }
}