using System;
using System.Collections.Generic;

namespace ETModel
{
    public static partial class LandUIType
    {
        public const string LandLogin = "LandLogin";
        public const string LandLobby = "LandLobby";
        public const string SetUserInfo = "SetUserInfo";
        public const string LandRoom = "LandRoom";
        public const string LandInteraction = "LandInteraction";


    }
    public static partial class UIEventType
    {
        public const string LandInitSceneStart = "LandInitSceneStart";
        public const string LandLoginFinish = "LandLoginFinish";
        public const string LandInitLobby = "LandInitLobby";
        public const string LandSetUserInfo = "LandSetUserInfo";
        public const string LandSetUserInfoFinish = "LandSetUserInfoFinish";
        public const string LandClientLogoutFinish = "LandClientLogoutFinish";
    }

    [Event(UIEventType.LandInitSceneStart)]
    public class InitSceneStart_CreateLandLogin : AEvent
    {
        public override void Run()
        {
            Game.Scene.GetComponent<UIComponent>().Create(LandUIType.LandLogin);
        }
    }

    //初始化大厅界面事件方法
    [Event(UIEventType.LandInitLobby)]
    public class LandInitLobby_CreateLandLobby : AEvent
    {
        public override void Run()
        {
            Game.Scene.GetComponent<UIComponent>().Create(LandUIType.LandLobby);
        }
    }

    //Test09
    //练习1

    [Event(UIEventType.LandLoginFinish)]
    public class InitSceneStart_EndLandLogin : AEvent
    {
        public override void Run()
        {
            Game.Scene.GetComponent<UIComponent>().Remove(LandUIType.LandLogin);

            //练习09
            /*
            Log.Info("==>LandLoginFinished");

            Test0901Component tc = Game.Scene.GetComponent<Test0901Component>();
            tc.itime--;
            Log.Info($"===>Test0901Component:{tc.itime}");
            */
        }
    }

    [Event(UIEventType.LandSetUserInfo)]
    public class LandSetUserInfo : AEvent
    {
        public override void Run()
        {
            Game.Scene.GetComponent<UIComponent>().Create(LandUIType.SetUserInfo);
        }
    }

    [Event(UIEventType.LandSetUserInfoFinish)]
    public class LandSetUserInfoFinish : AEvent
    {
        public override void Run()
        {
            Game.Scene.GetComponent<UIComponent>().Remove(LandUIType.SetUserInfo);
        }
    }

    [Event(UIEventType.LandClientLogoutFinish)]
    public class LandClientLogoutFinish : AEvent
    {
        public override void Run()
        {
            Game.Scene.GetComponent<UIComponent>().Remove(LandUIType.LandLobby);
            Game.Scene.GetComponent<UIComponent>().Create(LandUIType.LandLogin);
        }
    }
}