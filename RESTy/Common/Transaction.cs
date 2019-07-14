using RESTy.Transaction.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTy.Common
{
    public class Transaction
    {
        public Transaction(IRESTfulRequest obj)
        {
            TransactionValidator.RequestValidator(obj);
        }
    }
}
