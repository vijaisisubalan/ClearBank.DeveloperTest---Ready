﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Rule
{
    public class ChapsPaymentRule:IPaymentRule
    {
        public bool IsValid(Account account, MakePaymentRequest request)
        {
            Func<Account, MakePaymentRequest, bool>[] paymentRules = { (x, y) => x == null, (x, y) => x.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.Chaps) == false, (x,y) => x.Status != AccountStatus.Live };
            return paymentRules.All(paymentRule => paymentRule(account, request) == false);

        }
    }
}
