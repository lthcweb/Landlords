using System;
using ETModel;

namespace ETHotfix
{
    [MessageHandler(AppType.Gate)]
    public class A1003_ClientLogout_Handler : AMRpcHandler<A1003_ClientLogout_C2G, A1003_ClientLogout_G2C>
    {
        protected override ETTask Run(Session session, A1003_ClientLogout_C2G request, A1003_ClientLogout_G2C response, Action reply)
        {
            throw new NotImplementedException();
        }
    }
}