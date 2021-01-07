using System;
using System.Collections.Generic;

namespace ETModel
{
    [ObjectSystem]
    public class Test0901ComponentAwakeSystem : AwakeSystem<Test0901Component>
    {
        public override void Awake(Test0901Component self)
        {
            self.Awake();
        }
    }
    public class Test0901Component : Component
    {
        public string str = "Test0901";
        public int itime = 999;

        public  void Awake()
        {
            Log.Info(str);

        }
    
    }
}