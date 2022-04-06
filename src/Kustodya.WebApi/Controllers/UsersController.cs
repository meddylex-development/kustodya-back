using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;
using Kustodya.ApplicationCore.Interfaces;

namespace Kustodya.WebApi.Controllers
{
    public class UsersController : BaseController
    {
        private readonly IValidateUser _iValidateUser;

        public UsersController(IValidateUser iValidateUser)
        {
            _iValidateUser = iValidateUser;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                await _iValidateUser.Validar(id);
            }
            catch (Exception)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}