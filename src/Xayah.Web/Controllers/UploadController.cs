using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Xayah.Application.Interfaces;
using Xayah.Application.ViewModels.Request;

namespace Xayah.Web.Controllers
{
    public class UploadController : Controller
    {
        public ITransactionAppService _transactionApp { get; set; }

        public UploadController(ITransactionAppService transactionApp)
        {
            _transactionApp = transactionApp;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(OFXUploadViewModelRequest ofxFileViewModel)
        {
            if (ModelState.IsValid)
            {
                await _transactionApp.UploadOFXFiles(ofxFileViewModel);

                return RedirectToAction("Index", "Home");
            }

            return View();
        }
    }
}