﻿using System.Threading.Tasks;
using System.Web.Mvc;
using Cloud.Web.Framework;

namespace Cloud.Web.Controllers
{
    public class AccountController : Controller
    {

        private readonly ISignin _signin;

        public AccountController(ISignin signin)
        {
            _signin = signin;
        }

        // GET: Account
        public async Task<ActionResult> Index()
        { 
            return View();
        }
    }
}