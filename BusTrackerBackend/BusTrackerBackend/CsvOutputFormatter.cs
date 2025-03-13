using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using Shared.DataTransferObjects;
using System.Text;

namespace BusTrackerBackend
{
    public class CsvOutputFormatter : TextOutputFormatter
    {
        public CsvOutputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/csv"));
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }

        protected override bool CanWriteType(Type? type)
        {
            if (typeof(BusDto).IsAssignableFrom(type)
                || typeof(IEnumerable<BusDto>).IsAssignableFrom(type))
            {
                return base.CanWriteType(type);
            }

            return false;
        }

        public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context,
            Encoding selectedEncoding)
        {
            var response = context.HttpContext.Response;
            var buffer = new StringBuilder();

            if (context.Object is IEnumerable<BusDto>)
            {
                foreach (var bus in (IEnumerable<BusDto>)context.Object)
                {
                    FormatCsv(buffer, bus);
                }
            }
            else
            {
                FormatCsv(buffer, (BusDto)context.Object);
            }

            await response.WriteAsync(buffer.ToString());
        }

        private static void FormatCsv(StringBuilder buffer, BusDto bus)
        {
            buffer.AppendLine($"{bus.Id},\"{bus.Capacity},\"{bus.PlateNumberAndModel}\"");
        }

    }
}
