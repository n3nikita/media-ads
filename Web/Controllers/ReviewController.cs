﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaAds.Core.Interfaces;
using MediaAds.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewController(IReviewRepository repository) => _reviewRepository = repository;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var reviews = await _reviewRepository.GetAllAsync();
            return Ok(reviews);
        }

        [HttpGet, Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var review = await _reviewRepository.GetByIdAsync(id);
            return Ok(review);
        }

        [HttpGet, Route("channel/{id:int}")]
        public async Task<IActionResult> GetByChannel(int id)
        {
            var reviews = await _reviewRepository.GetByChannel(id);
            return Ok(reviews);
        }

        [HttpGet, Route("channel/{link}")]
        public async Task<IActionResult> GetByChannel([FromRoute]string link)
        {
            var reviews = await _reviewRepository.GetByChannel(link);
            return Ok(reviews);
        }

        [HttpGet, Route("user/{id}")]
        public async Task<IActionResult> GetByUser(int id)
        {
            var reviews = await _reviewRepository.GetByUser(id);
            return Ok(reviews);
        }

        [HttpGet, Route("rating/{id}")]
        public async Task<IActionResult> GetAverageRating(int id)
        {
            var rating = await _reviewRepository.GetAverageRating(id);
            return Ok(rating);
        }

        [HttpPost, Authorize]
        public async Task<IActionResult> Post([FromBody]Review review)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            await _reviewRepository.CreateAsync(review);
            //return CreatedAtAction(nameof(Get), new { id = review.Id }, review);
            return RedirectToAction("Get", new { id = review.Id });
        }

    }
}