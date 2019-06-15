using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace FlixOne.API.Controllers
{
    /// <inheritdoc />
    public class HomeController : Controller
    {
        /// <summary>
        /// Home page
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Privacy page
        /// </summary>
        /// <returns></returns>
        public IActionResult Privacy()
        {
            return View();
        }
        /// <summary>
        /// Error page
        /// </summary>
        /// <returns></returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
    /// <summary>
    /// Error model
    /// </summary>
    public class ErrorViewModel
    {
        /// <summary>
        /// Request Id
        /// </summary>
        public string RequestId { get; set; }
        /// <summary>
        /// Show Request id
        /// </summary>
        public bool ShowRequestId { get; set; }
    }
}