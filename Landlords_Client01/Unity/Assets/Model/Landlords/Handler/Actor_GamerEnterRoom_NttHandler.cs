using UnityEngine;

namespace ETModel
{
    [MessageHandler]
    public class Actor_GamerEnterRoom_NttHandler : AMHandler<Actor_GamerEnterRoom_Ntt>
    {
        protected override async ETTask Run(ETModel.Session session, Actor_GamerEnterRoom_Ntt message)
        {
            UI uiRoom = Game.Scene.GetComponent<UIComponent>().Get(LandUIType.LandRoom);
            LandRoomComponent landRoomComponent = uiRoom.GetComponent<LandRoomComponent>();

            //��ƥ��״̬���л�Ϊ׼��״̬
            if (landRoomComponent.Matching)
            {
                landRoomComponent.Matching = false; //���뷿��ȡ��ƥ��״̬
                GameObject matchPrompt = uiRoom.GameObject.Get<GameObject>("MatchPrompt");
                
                uiRoom.GameObject.Get<GameObject>("Ready").SetActive(true);
                
            }

            //���δ��ʾ���
            for (int i = 0; i < message.Gamers.Count; i++)
            {
                //�������˷�����Ĭ�Ͽ�GamerInfo ����
                GamerInfo gamerInfo = message.Gamers[i];
                if (gamerInfo.UserID == 0)
                    continue;
                
                Gamer gamer = ETModel.ComponentFactory.Create<Gamer, long>(gamerInfo.UserID);
                landRoomComponent.AddGamer(gamer, i);    
            }

            await ETTask.CompletedTask;
        }
    }
}