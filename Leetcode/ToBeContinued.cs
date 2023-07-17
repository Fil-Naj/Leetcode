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
