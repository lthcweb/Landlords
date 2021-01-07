using System;
using System.Collections.Generic;

namespace ETModel
{
    public static partial class LandUIType
    {
        public const string LandLogin = "LandLogin";


    }
    public static partial class UIEventType 
    {
        public const string LandInitSceneStart = "LandInitSceneStart";
        public const string LandLoginFinish = "LandLoginFinish";
  }

    [Event(UIEventType.LandInitSceneStart)]
    public class InitSceneStart_CreateLandLogin : AEvent
    {
        public override void Run()
        {
            Game.Scene.GetComponent<UIComponent>().Create(LandUIType.LandLogin);
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
}