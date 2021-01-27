using System;
using System.Net;
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
                //验证Session
                if (!GateHelper.SignSession(session))
                {
                    response.Error = ErrorCode.ERR_UserNotOnline;
                    reply();
                    return;
                }

                
                User user = session.GetComponent<SessionUserComponent>().User;

              //移除session与user的绑定，全调用SessionUserComponent的Destory方法
                Log.Info($"移除UserID:{user.UserID} session与user的绑定");
                session.RemoveComponent<SessionUserComponent>();

                reply();

                await ETTask.CompletedTask;
            }
            catch(Exception e)
            {
                ReplyError(response, e, reply);
            }
        }
    }
}