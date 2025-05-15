using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoReview.Model
{
    public class UnixMillisecondsDateTimeConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateTimeOffset);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Integer)
            {
                long milliseconds = (long)reader.Value;
                return DateTimeOffset.FromUnixTimeMilliseconds(milliseconds);
            }
            else
            {
                throw new JsonReaderException($"Unexpected token type {reader.TokenType} when parsing DateTimeOffset.");
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
