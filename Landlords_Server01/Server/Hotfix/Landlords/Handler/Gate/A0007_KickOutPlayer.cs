﻿using System;
using System.Net;
using ETModel;

namespace ETHotfix
{
    [MessageHandler(AppType.Gate)]
    public class A0007_KickOutPlayer : AMRpcHandler<A0007_KickOutPlayer_R2G, A0007_KickOutPlayer_G2R>
    {
        protected override async ETTask Run(Session session, A0007_KickOutPlayer_R2G request, A0007_KickOutPlayer_G2R response, Action reply)
        {
            try
            {
                //获取此UserID的网关session
                long sessionId = Game.Scene.GetComponent<UserComponent>().Get(request.UserID).GateSessionID;
                Session lastSession = Game.Scene.GetComponent<NetOuterComponent>().Get(sessionId);

                //移除session与user的绑定
                lastSession.RemoveComponent<SessionUserComponent>();
                Log.Info($"移除UserID:{request.UserID} session与user的绑定");

                reply();

                await ETTask.CompletedTask;
                //服务端主动断开客户端连接
                Game.Scene.GetComponent<NetOuterComponent>().Remove(sessionId);
                Log.Info($"将玩家{request.UserID} 连接断开");
            }
            catch (Exception e)
            {
                ReplyError(response, e, reply);
            }

        }
    }
}