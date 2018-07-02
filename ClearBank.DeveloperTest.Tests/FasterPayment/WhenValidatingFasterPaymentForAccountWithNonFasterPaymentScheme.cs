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
    public class WhenValidatingFasterPaymentForAccountWithNonFasterPaymentScheme: Specification
    {
        private FasterPaymentRule fasterPaymentRule;
        private MakePaymentRequest makePaymentRequest;
        private Account account;
        private bool result;
        public WhenValidatingFasterPaymentForAccountWithNonFasterPaymentScheme()
        {
            fasterPaymentRule = new FasterPaymentRule();
            makePaymentRequest = new PaymentRequestBuilder()
                .WithAmount(500m)
                .WithCredtorAccountNumber("CredtorAccountNumber")
                .WithDebtorAccountNumber("DebtorAccountNumber")
                .WithPaymentScheme(PaymentScheme.Bacs)
                .WithPaymentDate(DateTime.Now)
                .Build();
            account = new AccountBuilder()
                .WithAccountNumber("AccountNumber")
                .WithAllowedPaymentSchemes(AllowedPaymentSchemes.Chaps)
                .WithBalance(1000m)
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
            result.ShouldBeFalse("Payment Scheme is Not valid with this Account");
        }
    }
}
