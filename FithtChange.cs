using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace com.ams.pistola.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThirdChangeController : ControllerBase
    {
        // Add constructor
        public ThirdChangeController()
        {
            // code here ..
        }
    }

[HttpGet]
        [Route("api/prereturn/lps")]
        public IActionResult preReturnLps() {
            var listLps = _context.TStoredItem.Where(w => w.LocationId == "TJ-STAGE-01").GroupBy(o => o.HuId).Select(
                s => new {
                    huId = s.Key,
                    qty = s.Sum( sum => sum.ActualQty)
                }).ToList();

            return Ok(listLps);
        }

}
