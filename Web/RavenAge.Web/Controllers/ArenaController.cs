﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RavenAge.Web.Controllers
{
    public class ArenaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}