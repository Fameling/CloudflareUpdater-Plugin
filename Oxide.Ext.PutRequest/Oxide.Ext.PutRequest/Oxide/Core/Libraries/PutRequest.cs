using System.Collections.Generic;
using Oxide.Ext.PutRequest;

namespace Oxide.Core.Libraries
{
    public class PutRequest : Library
    {
        [LibraryFunction("PutRequest")]
        public string DoRequest(string Url, Dictionary<string, string> Headers, Dictionary<string, object> Data)
        {
            Request request = new Request();
            request.Url = Url;
            request.Headers = Headers;
            request.Data = Data;
            return request.RunRequest();
        }
    }
}