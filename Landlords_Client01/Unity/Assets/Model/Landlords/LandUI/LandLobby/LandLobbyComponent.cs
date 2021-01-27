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
    /// �����������
    /// </summary>
    public class LandLobbyComponent : Component
    {
        //��ʾ�ı�
        public Text prompt;
        //�������
        private Text name;
        //��ҽ�Ǯ
        private Text money;
        //��ҵȼ�
        private Text level;
        //�绰
        public Text phone;
        //����
        public Text email;
        //�Ա�
        public Text sex;
        //�ƺ�
        public Text title;

        public bool isMatching;

        private bool isLogouting;

        public void Awake()
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
            //ƥ����뷿�䰴ť
            rc.Get<GameObject>("Landlords").GetComponent<Button>().onClick.Add(OnStartMatchLandlords);

            //��ӽ��뷿��ƥ���¼�
            //...

            //����µ�ƥ��Ŀ��
            //...

            //��ȡ�������
            GetUserInfo();
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
                //A1003_ClientLogout_C2G clientLogout_Req = new A1003_ClientLogout_C2G();
                //A1003_ClientLogout_G2C messageGate = await SessionComponent.Instance.Session.Call(clientLogout_Req) as A1003_ClientLogout_G2C;

                A1003_ClientLogout_C2G clientLogout_Req = new A1003_ClientLogout_C2G();
                A1003_ClientLogout_G2C GetUserInfo_Ack = await SessionComponent.Instance.Session.Call(clientLogout_Req) as A1003_ClientLogout_G2C;
                this.isLogouting = false;


                //�жϵ�½Gate���������ؽ��
                if (GetUserInfo_Ack.Error == ErrorCode.ERR_ConnectGateKeyError)
                {
                    // login.prompt.text = "�������ط�������ʱ";
                    // login.account.text = "";
                    // login.password.text = "";
                    // sessionGate.Dispose();
                    // login.isLogining = false;
                    Log.Error("�������ط�������ʱ");
                    return;
                }

                //�Ͽ��������������
                long sessionId = SessionComponent.Instance.Session.Id;
                Game.Scene.GetComponent<NetOuterComponent>().Remove(sessionId);

                //���еǳ��¼�
                Game.EventSystem.Run(UIEventType.LandClientLogoutFinish);
            }
            catch(Exception e)
            {
                Log.Error(e);
            }
        }

        private async void GetUserInfo()
        {
            A1001_GetUserInfo_C2G GetUserInfo_Req = new A1001_GetUserInfo_C2G();
            A1001_GetUserInfo_G2C GetUserInfo_Ack = await SessionComponent.Instance.Session.Call(GetUserInfo_Req) as A1001_GetUserInfo_G2C;


            //��ʾ�û������û��ȼ�
            //name.text = GetUserInfo_Ack.NickName;
            name.text = GetUserInfo_Ack.UserName;
            money.text = GetUserInfo_Ack.Money.ToString();
            level.text = GetUserInfo_Ack.Level.ToString();
            phone.text = GetUserInfo_Ack.Phone.ToString();
            email.text = GetUserInfo_Ack.Email;
            sex.text = GetUserInfo_Ack.Sex;
            title.text = GetUserInfo_Ack.Title;

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

        /// <summary>
        /// ƥ�䶷����
        /// </summary>
        public async void OnStartMatchLandlords()
        {
            try
            {
                //���Ϳ�ʼƥ����Ϣ
                C2G_StartMatch_Req c2G_StartMatch_Req = new C2G_StartMatch_Req();
                G2C_StartMatch_Back g2C_StartMatch_Ack = (G2C_StartMatch_Back)await SessionComponent.Instance.Session.Call(c2G_StartMatch_Req);

                if (g2C_StartMatch_Ack.Error == ErrorCode.ERR_UserMoneyLessError)
                {
                    Log.Error("����");
                    return;
                }

                //�л����������
                UI landRoom = Game.Scene.GetComponent<UIComponent>().Create(LandUIType.LandRoom);
                Game.Scene.GetComponent<UIComponent>().Remove(LandUIType.LandLobby);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }
    }
}