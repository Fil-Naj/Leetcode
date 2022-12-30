using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class ToBeContinuedAttribute : Attribute
    {
        private readonly string _reason;

        public ToBeContinuedAttribute(string reason)
        {
            _reason = reason;
        }
    }
}
