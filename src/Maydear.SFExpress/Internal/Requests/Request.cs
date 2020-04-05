using System;
using System.Collections.Generic;
using System.Text;

namespace Maydear.SFExpress.Internal.Requests
{
    internal class Request<T> : IRequestBody where T : IRequestBody
    {
        public Request(T body, string head)
        {
            Body = body;
            Head = head;
        }
        public string Head { get; private set; }

        public T Body { get; private set; }

        public string ServiceName => throw new NotImplementedException();

        public string ToXml()
        {
            return $@"<?xml version='1.0' encoding='UTF-8'?><Request service='{Body.ServiceName}' lang='zh-CN'><Head>{Head}</Head><Body>{Body.ToXml()}</Body></Request>";
        }
    }
}
