using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClearBank.DeveloperTest.Rule;
using ClearBank.DeveloperTest.Tests.TestBuilder;
using ClearBank.DeveloperTest.Types;
using Xunit.Extensions;

namespace ClearBank.DeveloperTest.Tests.FasterPayment
{
    public class WhenValidatingFasterPaymentForAccountWithFasterPaymentScheme: Specification
    {
        private readonly FasterPaymentRule fasterPaymentRule;
        private readonly MakePaymentRequest makePaymentRequest;
        private bool result;
        private Account account ;
        public WhenValidatingFasterPaymentForAccountWithFasterPaymentScheme()
        {
            fasterPaymentRule = new FasterPaymentRule();
            makePaymentRequest = new PaymentRequestBuilder()
                .WithAmount(1000m)
                .WithCredtorAccountNumber("CredtorAccountNumber")
                .WithDebtorAccountNumber("DebtorAccountNumber")
                .WithPaymentScheme(PaymentScheme.FasterPayments)
                .WithPaymentDate(DateTime.Now)
                .Build();

            account = new AccountBuilder()
                .WithAccountNumber("AccountNumber")
                .WithAllowedPaymentSchemes(AllowedPaymentSchemes.FasterPayments)
                .WithBalance(1001m)
                .WithStatus(AccountStatus.Live)
                .Build();
        }

        protected override void Observe()
        {
            
            result = fasterPaymentRule.IsValid(account, makePaymentRequest);
        }

        [Observation]
        public void Result()
        {
            result.ShouldBeTrue("Payment Scheme is valid with this Account");
        }
    }
}
