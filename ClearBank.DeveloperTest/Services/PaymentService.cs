using ClearBank.DeveloperTest.Data;
using ClearBank.DeveloperTest.Types;
using System.Configuration;
using ClearBank.DeveloperTest.Rule;

namespace ClearBank.DeveloperTest.Services
{
    public class PaymentService : IPaymentService
    {
        public IAccountDataStore AccountDataStore;

        public PaymentService(IAccountDataStore accountDataStore)
        {
            AccountDataStore = accountDataStore;
        }

        public MakePaymentResult MakePayment(MakePaymentRequest request)
        {
            var account = AccountDataStore.GetAccount(request.DebtorAccountNumber);
            var paymentRule = PaymentRule.GetPaymentRule(request.PaymentScheme);
            if (paymentRule.IsValid(account, request))
            {
                account.Balance -= request.Amount;
                AccountDataStore.UpdateAccount(account);
                return new MakePaymentResult() {Success = true};
            }
            return new MakePaymentResult();
        }
    }
}
