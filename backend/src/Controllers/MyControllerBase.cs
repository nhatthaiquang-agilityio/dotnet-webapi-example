using Microsoft.AspNetCore.Mvc;


namespace WebApiSample.Controllers
{
    #region snippet_MyControllerBase
    [Produces("application/json")]
    [ApiController]
    public class MyControllerBase : ControllerBase
    {
    }

    #endregion
}