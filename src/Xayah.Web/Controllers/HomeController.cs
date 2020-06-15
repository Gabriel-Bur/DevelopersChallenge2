using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Xayah.Application.Interfaces;
using Xayah.Application.ViewModels.Response;
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
            IList<TransactionViewModelResponse> transactionList = await _transactionApp.GetAllTransactions();

            return View(transactionList.OrderByDescending(x => x.DateTime));
        }

        public async Task<IActionResult> Details(Guid id)
        {
            TransactionViewModelResponse transaction =await _transactionApp.GetById(id);

            return View(transaction);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
