using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace com.ams.pistola.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigurationController : ControllerBase
    {
        // code her
        
        // constructor
        public ConfigurationController()
        {
        }
        
        [HttpPost]
        [Route("api/login")]
        public IActionResult loginHJ([FromBody] LoginDTO user) {
            IActionResult response = Unauthorized();
            JWT jwt = new JWT(_config);
            var usr = _context.Employees.Where(w => w.Id == user.userName && w.Password == user.password && w.Enabled == true).FirstOrDefault();
            if (usr != null) {
                var roles = _context.UserRole.Where(w => w.UserId == usr.EmployeeId).Select(s => s.RoleId).ToList();
                var permissions  = _context.RolePermission.Where(w => roles.Contains(w.RoleId)).Select(s => s.Permission.Permission1).ToList();

                usr.LastLoginDate = DateTime.Now;
                _context.SaveChanges();
                    var tokenString = jwt.GenerateJWTToken(usr, permissions);
                response = Ok(new
                {
                    token = tokenString,
                    userDetails = usr,
                });
            }
            return response;
        }
        
    }
}
