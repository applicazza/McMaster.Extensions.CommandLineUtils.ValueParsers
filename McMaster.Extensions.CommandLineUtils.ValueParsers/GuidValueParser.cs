using System;
using System.Globalization;
using McMaster.Extensions.CommandLineUtils.Abstractions;

namespace McMaster.Extensions.CommandLineUtils.ValueParsers
{
    public class GuidValueParser : IValueParser<Guid>
    {
        object IValueParser.Parse(string argName, string value, CultureInfo culture)
        {
            return Parse(argName, value, culture);
        }

        public Guid Parse(string argName, string value, CultureInfo culture)
        {
            Guid.TryParse(value, out var result);
            return result;
        }

        public Type TargetType { get; } = typeof(Guid);
    }
}