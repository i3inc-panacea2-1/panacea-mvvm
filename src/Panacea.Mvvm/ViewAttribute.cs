using System;

namespace Panacea.Mvvm
{
    public sealed class ViewAttribute:Attribute
    {
        public Type Type { get; }
        public ViewAttribute(Type type)
        {
            Type = type;
        }
    }
}
