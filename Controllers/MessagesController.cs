using Microsoft.AspNetCore.Mvc;

namespace SecurityAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class MessagesController : Controller
    {
        [HttpPost("InsertMessage")]
        public void InsertMessage(string user , string toUser ,string message)
        { 
            Message m = new(user, toUser, message, DateTime.Now);
            CoreApp.AddMessage(m);
        }
    }
}
