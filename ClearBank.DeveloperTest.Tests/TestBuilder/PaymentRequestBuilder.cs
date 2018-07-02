using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Tests.TestBuilder
{
    public class PaymentRequestBuilder
    {
        private decimal requestAmount;
        private PaymentScheme requestPaymentSchemes;
        private string requestCredtorAccountNumber ;
        private string requestDebtorAccountNumber;
        private DateTime requestPaymentDate;

        public MakePaymentRequest Build()
        {
            return new MakePaymentRequest()
            {
                Amount = requestAmount,
                PaymentScheme = requestPaymentSchemes,
                DebtorAccountNumber = requestDebtorAccountNumber,
                CreditorAccountNumber = requestCredtorAccountNumber,
                PaymentDate = requestPaymentDate
            };
        }

        public PaymentRequestBuilder WithPaymentScheme(PaymentScheme paymentScheme)
        {
            requestPaymentSchemes = paymentScheme;
            return this;
        }

        public PaymentRequestBuilder WithAmount(decimal amount)
        {
            requestAmount = amount;
            return this;
        }

        public PaymentRequestBuilder WithCredtorAccountNumber(string credtorAccountNumber)
        {
            requestCredtorAccountNumber = credtorAccountNumber;
            return this;
        }

        public PaymentRequestBuilder WithDebtorAccountNumber(string debtorAccountNumber)
        {
            requestDebtorAccountNumber = debtorAccountNumber;
            return this;
        }

        public PaymentRequestBuilder WithPaymentDate(DateTime paymentDate)
        {
            requestPaymentDate = paymentDate;
            return this;
        }


    }
}
