using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dataract.e5.WM.Interface
{
    public interface IRequestManager
    {
        object Process(string messageCode, string workspaceId, Dictionary<string, object> postData);
    }
}