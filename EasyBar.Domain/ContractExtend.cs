using Flunt.Validations;
using System;

namespace EasyBar.Domain
{
    public static class ContractExtend
    {
        public static Contract IsGuid(this Contract contract, string val, string property, string message)
        {
            Guid guid;
            var isValid =  Guid.TryParse(val, out guid);

            if (!isValid)
                contract.AddNotification(property, message);

            return contract;      
        }
    }
}
