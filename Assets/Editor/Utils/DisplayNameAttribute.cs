using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = false)]
sealed class DisplayNameAttribute : Attribute
{
    readonly string displayName;

    public DisplayNameAttribute(string displayName)
    {
        this.displayName = displayName;
    }

    public string DisplayName
    {
        get { return displayName; }
    }
}
