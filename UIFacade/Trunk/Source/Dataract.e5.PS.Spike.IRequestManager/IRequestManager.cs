using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dataract.e5.PS.Spike.Interfaces
{
    public interface IRequestManager
    {
        object Process(string messageCode, string workspaceId, Dictionary<string, object> postData);
    }
}