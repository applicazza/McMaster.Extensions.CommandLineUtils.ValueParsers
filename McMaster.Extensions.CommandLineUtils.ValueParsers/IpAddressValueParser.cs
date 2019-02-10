using System;
using System.Globalization;
using System.Net;
using McMaster.Extensions.CommandLineUtils.Abstractions;

namespace McMaster.Extensions.CommandLineUtils.ValueParsers
{
    public class IpAddressValueParser : IValueParser<IPAddress>
    {
        object IValueParser.Parse(string argName, string value, CultureInfo culture)
        {
            return Parse(argName, value, culture);
        }

        public IPAddress Parse(string argName, string value, CultureInfo culture)
        {
            IPAddress.TryParse(value, out var result);
            return result;
        }

        public Type TargetType { get; } = typeof(IPAddress);
    }
}