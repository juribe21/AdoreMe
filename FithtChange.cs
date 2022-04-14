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
            var configurationOptions = new ConfigurationOptions()
            {
                EndPoints = { string.Concat(_redisSettings.Host, ":", _redisSettings.Port) },
                AbortOnConnectFail = _redisSettings.AbortOnConnectFail,
                AsyncTimeout = _redisSettings.AsyncTimeOutMilliSecond,
                ConnectTimeout = _redisSettings.ConnectTimeOutMilliSecond
            };
        }
    }

public async void ConnectServer()
        {
            var configurationOptions = new ConfigurationOptions()
            {
                EndPoints = { string.Concat(_redisSettings.Host, ":", _redisSettings.Port) },
                AbortOnConnectFail = _redisSettings.AbortOnConnectFail,
                AsyncTimeout = _redisSettings.AsyncTimeOutMilliSecond,
                ConnectTimeout = _redisSettings.ConnectTimeOutMilliSecond
            };

            _connectionMultiplexer = await ConnectionMultiplexer.ConnectAsync(configurationOptions);
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
