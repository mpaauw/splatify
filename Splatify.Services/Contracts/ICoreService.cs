using Splatify.Core;
using Splatify.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace Splatify.Services
{
    [ServiceContract]
    interface ICoreService
    {
        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/testapi",
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        string TestAPI(string test);
    }
}
