﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace $safeprojectname$.Controllers
{
    public class CargosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}