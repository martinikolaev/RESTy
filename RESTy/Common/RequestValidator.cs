using RESTy.Transaction.Extensions;
using RESTy.Transaction.Helpers;
using RESTy.Transaction.Interfaces;
using System;
using System.Text;

namespace RESTy.Common
{
    internal static class RequestValidator
    {
        /// <summary>
        /// Will validate that <paramref name="transactionObject"/> has all required properties instantiated.
        /// </summary>
        /// <typeparam name="TRequest">Transaction object</typeparam>
        /// <param name="transactionObject"></param>
        /// <exception cref="InvalidOperationException">If non instanciated Required properties are being found.</exception>
        public static bool Validate<TRequest>(TRequest transactionObject) where TRequest : ITransaction
        {
            StringBuilder exceptionMessage = new StringBuilder($"The following properties in {typeof(TRequest)} are declared as Required but not instanciated in this transaction: {Environment.NewLine}");

            int counter = 0;

            var properties = Reflection.GetAllProperties(transactionObject);

            // loop thorugh all props
            foreach (var prop in properties)
            {
                // find a required property
                if (prop.IsRequired())
                {
                    if(prop.GetValue(transactionObject) == null)
                    {
                        counter++;
                        exceptionMessage.Append($"{prop.Name} is not instanciated. {Environment.NewLine}");
                    }
                }
            }

            return counter == 0 ? true : throw new InvalidOperationException(exceptionMessage.ToString());
        }
    }
}
