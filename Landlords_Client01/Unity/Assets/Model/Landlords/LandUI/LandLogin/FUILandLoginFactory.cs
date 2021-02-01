using FairyGUI;

namespace ETModel
{
    public static class FUILandLoginFactory
    {
        public static void Create()
        {
            FUIComponent fuiComponent = Game.Scene.GetComponent<FUIComponent>();
            //从整个LandFUI资源包中取得并创建LandLogin登录界面资源
            FUI fui = ComponentFactory.Create<FUI, GObject>(UIPackage.CreateObject(FUIType.LandFUI, FUIType.LandLogin));
            fui.Name = FUIType.LandLogin;
            //给fui添加LandLoginComponent组件，此组件是给UI元件添加事件方法
            fui.AddComponent<FUILandLoginComponent>();
            //把登录界面fui添加到全局的FUI组件中
            fuiComponent.Add(fui);
        }
    }
}