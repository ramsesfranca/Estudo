using Microsoft.AspNetCore.Mvc;

namespace RF.Estudo.API.Controllers
{
    [ApiController, Route("api/v{version:apiVersion}/[controller]")]
    public abstract class BaseController : ControllerBase
    {
    }
}
