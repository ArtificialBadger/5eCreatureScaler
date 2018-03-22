using System;

namespace CreatureScaler.Rules
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public sealed class TokenHeadAttribute : Attribute
    {
        public TokenHeadAttribute(string head)
        {
            this.Head = head.ToLower();
        }

        public string Head { get; }
    }
}
