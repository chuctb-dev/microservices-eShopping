﻿using Microsoft.AspNetCore.Mvc;

namespace eShopping.Ordering.Api.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase;
}
