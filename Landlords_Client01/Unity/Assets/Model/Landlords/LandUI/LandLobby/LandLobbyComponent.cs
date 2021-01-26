using System;
using UnityEngine;
using UnityEngine.UI;

namespace ETModel
{
    [ObjectSystem]
    public class LandLobbyComponentAwakeSystem : AwakeSystem<LandLobbyComponent>
    {
        public override void Awake(LandLobbyComponent self)
        {
            self.Awake();
        }
    }

    /// <summary>
    /// 大厅界面组件
    /// </summary>
    public class LandLobbyComponent : Component
    {
        //提示文本
        public Text prompt;
        //玩家名称
        private Text name;
        //玩家金钱
        private Text money;
        //玩家等级
        private Text level;
        //电话
        public Text phone;
        //邮箱
        public Text email;
        //性别
        public Text sex;
        //称号
        public Text title;

        public bool isMatching;

        private bool isLogouting;

        public async void Awake()
        {
            ReferenceCollector rc = this.GetParent<UI>().GameObject.GetComponent<ReferenceCollector>();

            prompt = rc.Get<GameObject>("Prompt").GetComponent<Text>();
            name = rc.Get<GameObject>("Name").GetComponent<Text>();
            money = rc.Get<GameObject>("Money").GetComponent<Text>();
            level = rc.Get<GameObject>("Level").GetComponent<Text>();
            phone = rc.Get<GameObject>("Phone").GetComponent<Text>();
            email = rc.Get<GameObject>("Email").GetComponent<Text>();
            sex = rc.Get<GameObject>("Sex").GetComponent<Text>();
            title = rc.Get<GameObject>("Title").GetComponent<Text>();

            rc.Get<GameObject>("SetUserInfo").GetComponent<Button>().onClick.Add(OnSetUserInfo);
            rc.Get<GameObject>("Logout").GetComponent<Button>().onClick.Add(OnLogout);

            //添加进入房间匹配事件
            //...

            //添加新的匹配目标
            //...

            //获取玩家数据
            A1001_GetUserInfo_C2G GetUserInfo_Req = new A1001_GetUserInfo_C2G();
            A1001_GetUserInfo_G2C GetUserInfo_Ack = await SessionComponent.Instance.Session.Call(GetUserInfo_Req) as A1001_GetUserInfo_G2C;


            //显示用户名和用户等级
            //name.text = GetUserInfo_Ack.NickName;
            name.text = GetUserInfo_Ack.UserName;
            money.text = GetUserInfo_Ack.Money.ToString();
            level.text = GetUserInfo_Ack.Level.ToString();
            phone.text = GetUserInfo_Ack.Phone.ToString();
            email.text = GetUserInfo_Ack.Email;
            sex.text = GetUserInfo_Ack.Sex;
            title.text = GetUserInfo_Ack.Title;
        }


        private async void OnLogout()
        {
            if (this.isLogouting || this.IsDisposed)
            {
                return;
            }
            this.isLogouting = true;

            try
            {
                A1003_ClientLogout_C2G clientLogout_Req = new A1003_ClientLogout_C2G() { };
                A1003_ClientLogout_G2C messageGate = await SessionComponent.Instance.Session.Call(clientLogout_Req) as A1003_ClientLogout_G2C;
                this.isLogouting = false;

                //判断登陆Gate服务器返回结果
                if (messageGate.Error == ErrorCode.ERR_ConnectGateKeyError)
                {
                    // login.prompt.text = "连接网关服务器超时";
                    // login.account.text = "";
                    // login.password.text = "";
                    // sessionGate.Dispose();
                    // login.isLogining = false;
                    Log.Error("连接网关服务器超时");
                    return;
                }

                Log.Error("连接网关服务器正常");
                //判断通过则退出Gate成功

                //断开与服务器的连接
                long sessionId = SessionComponent.Instance.Session.Id;
                Game.Scene.GetComponent<NetOuterComponent>().Remove(sessionId);

                //运行登出事件
                Game.EventSystem.Run(UIEventType.LandClientLogoutFinish);
            }
            catch(Exception e)
            {
                Log.Error(e);
            }
        }

        private void OnSetUserInfo()
        {
            Game.EventSystem.Run(UIEventType.LandSetUserInfo);
        }

        public void UpdateUserInfo(A1002_SetUserInfo_G2C info)
        {
            phone.text = info.Phone.ToString();
            email.text = info.Email;
            sex.text = info.Sex;
        }
    }
}