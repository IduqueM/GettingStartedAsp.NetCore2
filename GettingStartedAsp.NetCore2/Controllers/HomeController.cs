﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SampleCosmosCore2App.Core;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GettingStartedAsp.NetCore2.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        private Persistence _persistence;

        public HomeController(Persistence persistence)
        {
            _persistence = persistence;
        }

        [HttpGet()]
        public async Task<IActionResult> IndexAsync()
        {
            var samples = await _persistence.GetSamplesAsync();
            return View("Index", samples);
        }

        [HttpGet("Create")]
        public async Task<IActionResult> CreateAsync()
        {
            var sample = new Sample() { };
            return View("Get", sample);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(string id)
        {
            var sample = await _persistence.GetSampleAsync(id);
            return View("Get", sample);
        }

        [HttpPost()]
        public async Task<IActionResult> PostAsync([FromForm] Sample sample)
        {
            await _persistence.SaveSampleAsync(sample);
            return RedirectToAction("IndexAsync");
        }
    }
}
