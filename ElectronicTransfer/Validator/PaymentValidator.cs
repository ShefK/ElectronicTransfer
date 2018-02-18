using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using FluentValidation;

namespace ElectronicTransfer.Validator
{
    public class PaymentValidator : AbstractValidator<Payment>
    {
        public PaymentValidator()
        {
            RuleFor(payment => payment.BSB).Must(BeAValidBSB).WithMessage("Please specify a valid BSB");
            RuleFor(payment => payment.AccountNumber).Must(BeAValidAccountNumber).WithMessage("Please specify a valid Account Number");
            RuleFor(payment => payment.Amount).Must(BeAValidAmount).WithMessage("Please specify a valid Amount");

        }

        private bool BeAValidBSB(string BSB)
        {
            string bsb = BSB;

            System.Net.WebClient wc = new System.Net.WebClient();
            byte[] raw = wc.DownloadData("http://bsb.apca.com.au/public/CS4BSBDir.nsf/0/5E5C2A3A629B736DCA258227001192FD/$File/BSBDirectoryJan18-262.txt");

            string bsbData = System.Text.Encoding.UTF8.GetString(raw);

            if (string.IsNullOrEmpty(bsb))
            {
                return false;
            }

            if (!string.IsNullOrEmpty(bsb))
            {
                if (!bsbData.Contains(bsb))
                {
                    return false;
                }

                else
                    return true;
            }
            else
            {
                return true;
            }
        }


        private bool BeAValidAccountNumber(string accNumber)
        {
            bool validAccountNumber = false;
            if (!string.IsNullOrEmpty(accNumber))
            {
                 validAccountNumber = Regex.IsMatch(accNumber, "^[0-9]{6,10}$");
                
            }
            return validAccountNumber;
        }


        private bool BeAValidAmount(decimal amount)
        {
            bool validAmount = false;
            if (!string.IsNullOrEmpty(amount.ToString()))
            {
                validAmount = amount > 0;

            }
            return validAmount;
        }

    }
}