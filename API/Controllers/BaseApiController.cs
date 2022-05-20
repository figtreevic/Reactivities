using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    /* Controller is a placeholder that gets replaces
    with whatever the controller class name is 
    minus the word controller */
    public class BaseApiController : ControllerBase

    {
        
    }
}