﻿using RESTy.Transaction.Extensions;
using RESTy.Transaction.Helpers;
using RESTy.Transaction.Interfaces;
using System;
using System.Linq;
using System.Text;

namespace RESTy.Common
{
    internal static class RequestValidator
    {
        /// <summary>
        /// Validates that <paramref name="transactionObject"/> has all Required properties instantiated.
        /// </summary>
        /// <typeparam name="TRequest">Transaction object</typeparam>
        /// <param name="transactionObject"></param>
        /// <exception cref="InvalidOperationException">If non instanciated Required properties are being found.</exception>
        public static void Validate<TRequest>(TRequest transactionObject) where TRequest : ITransaction
        {
            StringBuilder exceptionMessage = new StringBuilder($"The following properties in {transactionObject.GetType()} are declared as Required but not instanciated in this transaction: {Environment.NewLine}");


            var violation = Reflection.GetAllProperties(transactionObject)
                                    .Where(p => p.IsRequired())
                                    .Where(p => p.GetValue(transactionObject) == null || string.IsNullOrWhiteSpace(p.GetValue(transactionObject).ToString()))
                                    .ToList();

            if (violation.Any())
            {
                violation.ForEach(p => exceptionMessage.Append($"{p.Name} - {Environment.NewLine}"));
                throw new InvalidOperationException(exceptionMessage.ToString());
            }
        }
    }
}
