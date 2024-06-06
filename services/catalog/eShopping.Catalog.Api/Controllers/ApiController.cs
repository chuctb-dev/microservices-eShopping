using Microsoft.AspNetCore.Mvc;

namespace eShopping.Catalog.Api.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/catalog/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase;
}
