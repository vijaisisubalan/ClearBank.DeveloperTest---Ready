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
    public class WhenValidatingFasterPaymentForAccountBalanceMoreThanRequestedAmount:Specification
    {
        private readonly FasterPaymentRule fasterPaymentRule;
        private readonly MakePaymentRequest makePaymentRequest;
        private bool result;
        private Account account;
        public WhenValidatingFasterPaymentForAccountBalanceMoreThanRequestedAmount()
        {

            fasterPaymentRule = new FasterPaymentRule();
            makePaymentRequest = new PaymentRequestBuilder()
                .WithAmount(500m)
                .WithCredtorAccountNumber("CredtorAccountNumber")
                .WithDebtorAccountNumber("DebtorAccountNumber")
                .WithPaymentScheme(PaymentScheme.FasterPayments)
                .WithPaymentDate(DateTime.Now)
                .Build();

            account = new AccountBuilder()
                .WithAccountNumber("AccountNumber")
                .WithAllowedPaymentSchemes(AllowedPaymentSchemes.FasterPayments)
                .WithBalance(501m)
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
            result.ShouldBeTrue("Account Balance is Valid");
        }
    }
}
