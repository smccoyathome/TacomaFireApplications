using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class FixedLengthString
{
	public string Value;

    private int p;
    private string sourceValue;
    public FixedLengthString(int length) : this(length, String.Empty)
    {
    }

    public FixedLengthString(int length, string sourceValue)
    {
        this.p = length;
        this.sourceValue = sourceValue;
        if (sourceValue.Length > length)
        {
            this.Value = sourceValue.Substring(0, length);
        }
        else
        {
            this.Value = sourceValue + new String((char)0, length - sourceValue.Length);
        }
    }
}

