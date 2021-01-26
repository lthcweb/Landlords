using System;
using ETModel;

namespace ETHotfix
{
    [MessageHandler(AppType.Gate)]
    public class A1003_ClientLogout_Handler : AMRpcHandler<A1003_ClientLogout_C2G, A1003_ClientLogout_G2C>
    {
        protected override async ETTask Run(Session session, A1003_ClientLogout_C2G request, A1003_ClientLogout_G2C response, Action reply)
        {
            try
            {
                Log.Info("收到登出请求");
                response.Error = ErrorCode.ERR_ConnectGateKeyError;
                //客户端提示：连接网关服务器超时
                reply();
                return;
            }
            catch(Exception e)
            {
                ReplyError(response, e, reply);
            }
        }
    }
}