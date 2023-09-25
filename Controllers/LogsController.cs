using Blog.Models.DB;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Blog.Controllers
{
    public class LogsController : Controller
    {
        private readonly IRequestRepository _requestRepository;
        public LogsController(IRequestRepository repository)
        {
            _requestRepository = repository;
        }

        public async Task<IActionResult> Index()
        {
            var requests = await _requestRepository.GetAll();
            return View(requests);
        }
    }
}
