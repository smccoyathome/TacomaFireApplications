using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
public static class IntegerExtensions
{
    //list of base number.
    public static readonly char[] VALUES = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'L', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'Y', //characters to Base48
  	    									 'Z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9','!', '"', '#', '$', '%', '&', 'ø', '(', ')', '*', '+', ',', '-', '/',  ':', ';', '<', '=', '>',  '`', 'Ç', 'ü', 'é', 'â', 'ä', 'à', 'å', 'ç', 'ê', 'ë', 'è', 'ï', 'î', 'ì', 'Ä','÷' };    //characters to Base95

    private const int MAXBUFFERBASE = 16;
    static char[] _baseBuffer = new char[MAXBUFFERBASE];

    private static string PositiveNumberToBase(long NumericValue, int @base,  int len = 0)
    {
        if (len > 0) {
            var maxByNumChars = Math.Pow(@base, len);
            if (NumericValue >= maxByNumChars)
                throw new NotSupportedException("The numeric value exceed the amount that can be allocated in the available space");
        }

        int currentBase = (int)@base;
        string result = string.Empty;
        var value = NumericValue;
        int idx = MAXBUFFERBASE - 1;

        while (value >= currentBase)
        {
            _baseBuffer[idx] = VALUES[value % currentBase];
            idx--;
            value = value / currentBase;
        }
        _baseBuffer[idx] = VALUES[value];

        return new String(_baseBuffer, idx, MAXBUFFERBASE - idx);
    }


    //Define direct calls not to add overload with calls and/or parameters

    public static string ToBase48ToString(this int number)
    {
        return PositiveNumberToBase(number,48);
    }

    public static string ToBase48ToString(this long number)
    {
        return PositiveNumberToBase(number,48);
    }

    public static string ToBase48ToString(this int number,int len)
    {
        return PositiveNumberToBase(number, 48,len);
    }

    public static string ToBase48ToString(this long number,int len)
    {
        return PositiveNumberToBase(number, 48,len);
    }
    public static string getNullByBase(int len)
    {
        return new String('~', len);
    }

    public static string ToBase95ToString(this int number)
    {
        return PositiveNumberToBase(number, 95);
    }

    public static string ToBase95ToString(this long number)
    {
        return PositiveNumberToBase(number, 95);
    }

    public static string ToBase95ToString(this int number, int len)
    {
        return PositiveNumberToBase(number, 95, len);
    }

    public static string ToBase95ToString(this long number, int len)
    {
        return PositiveNumberToBase(number, 95, len);
    }

}

