using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClearBank.DeveloperTest.Data;
using ClearBank.DeveloperTest.Services;
using ClearBank.DeveloperTest.Tests.TestBuilder;
using ClearBank.DeveloperTest.Types;
using Moq;
using Xunit.Extensions;

namespace ClearBank.DeveloperTest.Tests
{
    public class WhenAInValidPaymentRequestedForAAccount:Specification
    {
        private readonly string accountNumber = "AccountNumber";
        private PaymentService paymentService;
        private MakePaymentResult makePaymentResult;
        private Mock<IAccountDataStore> accountDataStore;
        private Account account;
        public WhenAInValidPaymentRequestedForAAccount()
        {
            accountDataStore = new Mock<IAccountDataStore>();
            account = new AccountBuilder()
                .WithAccountNumber("Acct123456")
                .WithAllowedPaymentSchemes(AllowedPaymentSchemes.FasterPayments)
                .WithBalance(500m)
                .WithStatus(AccountStatus.Live)
                .Build();

            accountDataStore.Setup(x => x.GetAccount(accountNumber)).Returns(account);
            paymentService = new PaymentService(accountDataStore.Object);
        }
        protected override void Observe()
        {
            var paymentRequestBuilder = new PaymentRequestBuilder()
                .WithDebtorAccountNumber(accountNumber)
                .WithAmount(1000m)
                .WithPaymentDate(DateTime.Now)
                .WithPaymentScheme(PaymentScheme.FasterPayments)
                .Build();

            makePaymentResult = paymentService.MakePayment(paymentRequestBuilder);
        }

        [Observation]
        public void Result()
        {
            makePaymentResult.Success.ShouldBeFalse("A IN Valid Payment Requested For a Account");
        }

    }
}
