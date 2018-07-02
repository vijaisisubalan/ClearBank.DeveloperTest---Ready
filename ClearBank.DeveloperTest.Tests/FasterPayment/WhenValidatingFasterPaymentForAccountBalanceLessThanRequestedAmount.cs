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
    public class WhenValidatingFasterPaymentForAccountBalanceLessThanRequestedAmount:Specification
    {
        private readonly FasterPaymentRule fasterPaymentRule;
        private readonly MakePaymentRequest makePaymentRequest;
        private bool result;
        private Account account;
        public WhenValidatingFasterPaymentForAccountBalanceLessThanRequestedAmount()
        {

            fasterPaymentRule = new FasterPaymentRule();
            makePaymentRequest = new PaymentRequestBuilder()
                .WithAmount(501m)
                .WithCredtorAccountNumber("CredtorAccountNumber")
                .WithDebtorAccountNumber("DebtorAccountNumber")
                .WithPaymentScheme(PaymentScheme.FasterPayments)
                .WithPaymentDate(DateTime.Now)
                .Build();

            account = new AccountBuilder()
                .WithAccountNumber("AccountNumber")
                .WithAllowedPaymentSchemes(AllowedPaymentSchemes.FasterPayments)
                .WithBalance(500m)
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
            result.ShouldBeFalse("Account Balance is Not Valid");
        }
    }
}
