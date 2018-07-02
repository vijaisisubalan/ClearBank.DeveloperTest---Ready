﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClearBank.DeveloperTest.Rule;
using ClearBank.DeveloperTest.Types;
using ClearBank.DeveloperTest.Tests.TestBuilder;
using Xunit.Extensions;

namespace ClearBank.DeveloperTest.Tests.Bacs
{
    public class WhenValidatingBacsPaymentWithNullAccount: Specification
    {
        private readonly BacsPaymentRule bacsPaymentRule ;
        private readonly MakePaymentRequest makePaymentRequest;
        private bool result;
        public WhenValidatingBacsPaymentWithNullAccount()
        {
            bacsPaymentRule = new BacsPaymentRule();
            makePaymentRequest = new PaymentRequestBuilder()
                .WithAmount(500m)
                .WithCredtorAccountNumber("CredtorAccountNumber")
                .WithDebtorAccountNumber("DebtorAccountNumber")
                .WithPaymentDate(DateTime.Now)
                .WithPaymentScheme(PaymentScheme.Bacs)
                .Build();
        }

        protected override void Observe()
        {
            Account account = new Account();
            result = bacsPaymentRule.IsValid(account, makePaymentRequest);
        }

        [Observation]
        public void Result()
        {
            result.ShouldBeFalse("Not a valid Account");       
        }
    }
}
