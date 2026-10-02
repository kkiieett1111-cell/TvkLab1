using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TvkLab1.Models;

namespace TvkLab1.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            List<Account> accounts = new List<Account>();
            return View(accounts);
        }

        // GET: Account/Create
        public ActionResult Create()
        {
            Account model = new Account();
            return View(model);
        }

        // POST: Account/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Account account)
        {
            if (ModelState.IsValid)
            {
     
                return RedirectToAction(nameof(Index));
            }
            return View(account);
        }

    
        [AcceptVerbs("GET", "POST")]
        public IActionResult VerifyPhone(string phone)
        {
            var _isPhone = new Regex(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$");
            if (string.IsNullOrEmpty(phone) || !_isPhone.IsMatch(phone))
            {
                return Json($"Số điện thoại {phone} Không đúng định dạng, VD: 0986421127 hoặc 098.421.1127");
            }
            return Json(true);
        }
    }
}