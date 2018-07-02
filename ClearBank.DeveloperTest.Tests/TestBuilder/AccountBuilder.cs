using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Tests.TestBuilder
{
    public class AccountBuilder
    {
        private string accountNumber;
        private AllowedPaymentSchemes allowedPaymentSchemes;
        private AccountStatus status;
        private decimal balance;
        public Account Build()
        {
            return new Account()
            {
                AccountNumber = accountNumber,
                AllowedPaymentSchemes = allowedPaymentSchemes,
                Status = status,
                Balance = balance
            };
        }

        public AccountBuilder WithAccountNumber(string withAccountNumber)
        {
            accountNumber = withAccountNumber;
            return this;
        }


        public AccountBuilder WithAllowedPaymentSchemes(AllowedPaymentSchemes withAllowedPaymentSchemes)
        {
            allowedPaymentSchemes = withAllowedPaymentSchemes;
            return this;
        }

        public AccountBuilder WithStatus(AccountStatus withAccountStatus)
        {
            status = withAccountStatus;
            return this;
        }

        public AccountBuilder WithBalance(decimal withBalance)
        {
            balance = withBalance;
            return this;
        }
    }
}
