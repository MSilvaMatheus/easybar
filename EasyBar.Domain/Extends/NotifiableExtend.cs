using Flunt.Notifications;
using Flunt.Validations;
using System;

namespace EasyBar.Domain.Extends
{
    public static class NotifiableExtend
    {
        public static Contract IsGuid(this Contract contract, string value)
        {
            Guid guid;
            var isValid = Guid.TryParse(value, out guid);

            return this;
        }

        public Contract IsGreaterThan(DateTime val, DateTime comparer, string property, string message)
        {
            if (val <= comparer)
                AddNotification(property, message);

            return this;
        }
    }
}
