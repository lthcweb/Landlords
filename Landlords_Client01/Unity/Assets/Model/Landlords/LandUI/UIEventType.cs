using System;
using System.Collections.Generic;

namespace ETModel
{

    public static partial class FUIType
    {
        public const string LandFUI = "LandFUI";
        public const string LandLogin = "LandLogin";

    }

    public static partial class UIEventType
    {
        public const string FUILandInitSceneStart = "FUILandInitSceneStart";
        public const string FUILandLoginFinish = "FUILandLoginFinish";
    }

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

    [Event(UIEventType.FUILandInitSceneStart)]
    public class InitSceneStart_CreateFUILandLogin : AEvent
    {
        public override void Run()
        {
            RunAsync().Coroutine();
        }

        public async ETVoid RunAsync()
        {
            
            FUIComponent fuiComponent = Game.Scene.GetComponent<FUIComponent>();
            //实际比例
            float ratioCurrent = fuiComponent.Root.GObject.actualWidth / fuiComponent.Root.GObject.actualHeight;
            //设计比例
            float ratioDesign = (float)1280 / (float)720;
            if (ratioCurrent > ratioDesign) //当前屏幕宽度超出
            {
                fuiComponent.Root.GObject.x -= (fuiComponent.Root.GObject.actualHeight * ratioDesign - fuiComponent.Root.GObject.actualWidth) / 2;
            }
            else if (ratioCurrent < ratioDesign)//当前屏幕高度超出
            {
                //Log.Debug("物体高度：" + self.Root.GObject.height + "物体宽度：" + self.Root.GObject.width + "真实高度" + self.Root.GObject.actualHeight + "真实宽度" + self.Root.GObject.actualWidth + "屏幕高度" + Screen.height + "屏幕宽度" + Screen.width);
                //真实设计高度 - 屏幕真实高度
                fuiComponent.Root.GObject.y -= (fuiComponent.Root.GObject.actualWidth / ratioDesign - fuiComponent.Root.GObject.actualHeight) / 2;
                //Log.Debug("理想高度为：" + self.Root.GObject.width / ratioDesign);
            }

            //加载一次FUI资源
            await Game.Scene.GetComponent<FUIPackageComponent>().AddPackageAsync(FUIType.LandFUI);
            
            //创建登陆界面
            FUILandLoginFactory.Create();
        }
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