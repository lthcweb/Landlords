namespace ETModel
{
    [ObjectSystem]
    public class FUILandLoginComponentAwakeSystem : AwakeSystem<FUILandLoginComponent>
    {
        public override void Awake(FUILandLoginComponent self)
        {
            self.Awake();
        }

    }

    public class FUILandLoginComponent : Component
    {
        //获取组件
        public FUI AccountInput;
        public FUI PasswordInput;
        public FUI Prompt;

        //是否正在登录中（避免登录请求还没响应时连续点击登录）
        public bool isLogining;
        //是否正在注册中（避免登录请求还没响应时连续点击注册）
        public bool isRegistering;

        public void Awake()
        {
            //获取父级"包"
            FUI LandLogin = this.GetParent<FUI>();

            //初始化数据
            this.AccountInput = LandLogin.Get("AccountInput");
            this.PasswordInput = LandLogin.Get("PasswordInput");
            this.Prompt = LandLogin.Get("Prompt");
            this.isLogining = false;
            this.isRegistering = false;

            //添加事件
            LandLogin.Get("LoginButton").GObject.asButton.onClick.Add(() => LoginBtnOnClick());
            LandLogin.Get("RegisterButton").GObject.asButton.onClick.Add(() => RegisterBtnOnClick());
        }

        public void LoginBtnOnClick()
        {
            //
            Log.Info("点击LoginBtn");
        }

        public void RegisterBtnOnClick()
        {
            //
            Log.Info("点击RegisterBtn");
        }
    }
}