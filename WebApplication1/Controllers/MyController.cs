using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication1.Helpers;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MyController : Controller
    {
 
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            string result = await TemplateHelper.ProcessTemplate();
            return new OkObjectResult(result);
        }
    }
}
