
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ElectronicTransfer.Models;
using ElectronicTransfer.Validator;
using FluentValidation.Results;

namespace ElectronicTransfer.Controllers
{

    public class HomeController : Controller
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(PaymentViewModel transferdetails)
        {  

            Payment payment = new Payment();
            payment.BSB = transferdetails.BSB;
            payment.AccountNumber = transferdetails.AccountNumber;
            payment.AccountName = transferdetails.AccountName;
            payment.Reference = transferdetails.Reference;
            payment.Amount = transferdetails.Amount;

            PaymentValidator validator = new PaymentValidator();
            ValidationResult results = validator.Validate(payment);

            if(results.Errors.Count == 0)
            {
                ViewBag.SuccessMessage = "Payment Successful!";

            }

            if(results.Errors.Count >0)
            {
                foreach (var error in results.Errors)
                {
                    ModelState.AddModelError(String.Empty, error.ErrorMessage);
                }
            }


            log.Info("payment details Start:");
            log.Info("BSB :"+ payment.BSB);
            log.Info("Account Number :"+ payment.AccountNumber);
            log.Info("Account Name :" + payment.AccountName);
            log.Info("Account Reference :" + payment.Reference);
            log.Info("Payment Amount :" + payment.Amount);
            log.Info("payment details End:");

            return View();
        }


    }
}
