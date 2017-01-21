using Splatify.Core;
using Splatify.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using System.Web;
using System.Linq;

namespace Splatify.Services
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(AddressFilterMode = AddressFilterMode.Any)]

    public sealed class CoreService : ICoreService
    {
        static CoreService()
        {

        }

        public string TestAPI(string test)
        {
            return "test";
        }
    }
}
