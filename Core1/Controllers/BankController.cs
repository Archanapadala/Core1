using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Core1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {

        [HttpGet]
        [Route("Consuming/GetData")]
        public IActionResult GetData()
        {

            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:5001/api/Regions");
                
                HttpResponseMessage response = client.GetAsync("api/GetAll").Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    return Ok(data);

                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }


        }
    }
}
