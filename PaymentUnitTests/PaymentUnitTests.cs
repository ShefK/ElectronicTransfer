using System;
using ElectronicTransfer.Validator;
using NUnit;
using NUnit.Framework;
using FluentValidation;
using FluentValidation.Results;

namespace PaymentUnitTests
{
    [TestFixture]
    public class PaymentUnitTests
    {
        Payment payment;
        
        public PaymentUnitTests()
        {
            payment = new Payment();
        }


        [TestCase("7468638",false)]
        [TestCase("062-223", true)]
        [TestCase("6483664386SDCC", true)]
        [TestCase(";:*&^", true)]
        [TestCase("", false)]
        public void IsValidBSB(string bsb, bool status)
        {
            payment.BSB = bsb;
            payment.AccountNumber = "123456";
            payment.AccountName = "Mr shdsmj";
            payment.Amount = 636;
            PaymentValidator validator = new PaymentValidator();
            ValidationResult results = validator.Validate(payment);

            Assert.AreEqual(results.IsValid, status);
        }


        [TestCase("123456", true)]
        [TestCase("DFGHJJ889", false)]
        [TestCase("", false)]
        public void IsValidAccountNumber(string accountNumber, bool status)
        {
            payment.BSB = "062-223";
            payment.AccountNumber = accountNumber;
            payment.AccountName = "Mr shdsmj";
            payment.Amount = 636;
            PaymentValidator validator = new PaymentValidator();
            ValidationResult results = validator.Validate(payment);

            Assert.AreEqual(results.IsValid, status);
        }


        [TestCase("scn mfdnc", true)]
        [TestCase("", false)]
        public void IsValidAccountName(string accountName, bool status)
        {
            payment.BSB = "062-223";
            payment.AccountNumber = "123456";
            payment.AccountName = accountName;
            payment.Amount = 636;
            PaymentValidator validator = new PaymentValidator();
            ValidationResult results = validator.Validate(payment);

            Assert.AreEqual(results.IsValid, status);
        }

        [TestCase("ags889c", false)]
        [TestCase("", false)]
        [TestCase(7889, true)]
        [TestCase(-7, false)]
        public void IsValidAmount(decimal amount, bool status)
        {
            payment.BSB = "062-223";
            payment.AccountNumber = "123456";
            payment.AccountName = "xcdh dmncs";
            payment.Amount = amount;
            PaymentValidator validator = new PaymentValidator();
            ValidationResult results = validator.Validate(payment);

            Assert.AreEqual(results.IsValid, status);
        }
    }
}
