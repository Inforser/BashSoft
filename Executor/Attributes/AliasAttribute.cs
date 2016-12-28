namespace Executor.Attributes
{
    using System;

    [AttributeUsage(AttributeTargets.Class)]
    public class AliasAttribute : Attribute
    {
        ////private string name;

        public AliasAttribute(string aliasName)
        {
            this.Name = aliasName;
        }

        public string Name { get; }

        public override bool Equals(object obj)
        {
            return this.Name.Equals(obj);
        }
    }
}
