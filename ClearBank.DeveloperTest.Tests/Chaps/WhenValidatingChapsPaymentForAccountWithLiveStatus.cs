using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClearBank.DeveloperTest.Rule;
using ClearBank.DeveloperTest.Tests.TestBuilder;
using ClearBank.DeveloperTest.Types;
using Xunit.Extensions;

namespace ClearBank.DeveloperTest.Tests.Chaps
{
    public class WhenValidatingChapsPaymentForAccountWithLiveStatus : Specification
    {
        private readonly ChapsPaymentRule chapsPaymentRule;
        private readonly MakePaymentRequest makePaymentRequest;
        private bool result;
        private Account account;
        public WhenValidatingChapsPaymentForAccountWithLiveStatus()
        {

            chapsPaymentRule = new ChapsPaymentRule();
            makePaymentRequest = new PaymentRequestBuilder()
                .WithAmount(500m)
                .WithCredtorAccountNumber("CredtorAccountNumber")
                .WithDebtorAccountNumber("DebtorAccountNumber")
                .WithPaymentScheme(PaymentScheme.Chaps)
                .WithPaymentDate(DateTime.Now)
                .Build();

            account = new AccountBuilder()
                .WithAccountNumber("AccountNumber")
                .WithAllowedPaymentSchemes(AllowedPaymentSchemes.Chaps)
                .WithBalance(501m)
                .WithStatus(AccountStatus.Live)
                .Build();
        }

        protected override void Observe()
        {

            result = chapsPaymentRule.IsValid(account, makePaymentRequest);
        }

        [Observation]
        public void Result()
        {
            result.ShouldBeTrue("Account Status is Valid");
        }
    }
}
