using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Xayah.Application.Interfaces;
using Xayah.Web.Models;

namespace Xayah.Web.Controllers
{
    public class HomeController : Controller
    {
        public ITransactionAppService _transactionApp { get; set; }

        public HomeController(ITransactionAppService transactionApp)
        {
            _transactionApp = transactionApp;
        }

        public async Task<IActionResult> Index()
        {
            var transactionList = await _transactionApp.GetAllTransactions();


            return View(transactionList);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
