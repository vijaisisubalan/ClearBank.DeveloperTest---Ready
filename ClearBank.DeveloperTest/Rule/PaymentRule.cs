using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Rule
{
    public static class PaymentRule
    {
        public static IPaymentRule GetPaymentRule(PaymentScheme paymentScheme)
        {

            var paymentRule =  new Dictionary<PaymentScheme, Func<IPaymentRule>>()
            {
                {PaymentScheme.Bacs, () => new BacsPaymentRule()},
                {PaymentScheme.Chaps, () => new ChapsPaymentRule()},
                {PaymentScheme.FasterPayments, () => new FasterPaymentRule()}
            };

            return paymentRule[paymentScheme]();
        }
    }
    }

