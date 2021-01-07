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
    }

    [Event(UIEventType.LandInitSceneStart)]
    public class InitSceneStart_CreateLandLogin : AEvent
    {
        public override void Run()
        {
            Game.Scene.GetComponent<UIComponent>().Create(LandUIType.LandLogin);
        }
    }
}