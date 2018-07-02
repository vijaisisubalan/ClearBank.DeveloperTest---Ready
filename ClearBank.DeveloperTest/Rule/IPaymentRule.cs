using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Rule
{
    public interface IPaymentRule
    {
        bool IsValid(Account account, MakePaymentRequest request);
    }
}
