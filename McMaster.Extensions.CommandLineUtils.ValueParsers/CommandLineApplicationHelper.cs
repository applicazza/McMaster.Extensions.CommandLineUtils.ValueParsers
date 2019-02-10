using McMaster.Extensions.CommandLineUtils.Abstractions;

namespace McMaster.Extensions.CommandLineUtils.ValueParsers
{
    public static class CommandLineApplicationHelper
    {
        public static void AddValueParsers(this CommandLineApplication app)
        {
            app.ValueParsers.AddRange(new IValueParser[]
            {
                new GuidValueParser(),
                new IpAddressValueParser(),
                new IpEndpointValueParser(),
            });
        }
    }
}