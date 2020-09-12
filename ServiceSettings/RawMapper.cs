using System.ServiceModel.Channels;

namespace ServiceSettings
{
    public class RawMapper : WebContentTypeMapper
    {
        public override WebContentFormat GetMessageFormatForContentType(string contentType)
        {
            return WebContentFormat.Raw;
        }
    }
}
