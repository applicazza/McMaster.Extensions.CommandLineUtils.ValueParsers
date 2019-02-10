using System;
using System.Globalization;
using System.Net;
using McMaster.Extensions.CommandLineUtils.Abstractions;

namespace McMaster.Extensions.CommandLineUtils.ValueParsers
{
    public class IpEndpointValueParser : IValueParser<IPEndPoint>
    {
        object IValueParser.Parse(string argName, string value, CultureInfo culture)
        {
            return Parse(argName, value, culture);
        }

        public IPEndPoint Parse(string argName, string value, CultureInfo culture)
        {
            var ep = value.Split(':');

            if (ep.Length < 2)
            {
                throw new FormatException("Invalid endpoint format");
            }
            
            IPAddress ip;
            
            if (ep.Length > 2)
            {
                if (!IPAddress.TryParse(string.Join(":", ep, 0, ep.Length - 1), out ip))
                {
                    throw new FormatException("Invalid ip address");
                }
            }
            else
            {
                if (!IPAddress.TryParse(ep[0], out ip))
                {
                    throw new FormatException("Invalid ip address");
                }
            }

            if (!int.TryParse(ep[ep.Length - 1], NumberStyles.None, NumberFormatInfo.CurrentInfo, out var port))
            {
                throw new FormatException("Invalid port");
            }

            return new IPEndPoint(ip, port);
        }

        public Type TargetType { get; } = typeof(IPEndPoint);
    }
}