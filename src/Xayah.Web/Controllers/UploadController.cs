using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Index(OFXFileViewModelRequest ofxFileViewModel)
        {
            if (ModelState.IsValid)
            {
                _transactionApp.SaveTransaction(ofxFileViewModel);
            }

            return View();
        }
    }
}