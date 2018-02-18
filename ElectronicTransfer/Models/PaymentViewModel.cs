using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ElectronicTransfer.Models
{
    public class PaymentViewModel
    {
        [Required(ErrorMessage = "BSB is required")]
        [Display(Name = "Enter BSB:")]
        public string BSB { get; set; }

        [Required(ErrorMessage = "Account Number is required")]
        [Display(Name = "Enter Account Number:")]
        public string AccountNumber { get; set; }

        [Required(ErrorMessage = "Account Name is required")]
        [Display(Name = "Enter Account Name:")]
        public string AccountName { get; set; }


        [Display(Name = "Reference:")]
        public string Reference { get; set; }

        [Required(ErrorMessage = "Payment Amount is required")]
        [Display(Name = "Enter Payment Amount$:")]
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }

       

    }
}