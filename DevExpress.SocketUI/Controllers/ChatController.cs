using Microsoft.AspNetCore.Mvc;

namespace DevExpress.SocketUI.Controllers
{
    public class ChatController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
