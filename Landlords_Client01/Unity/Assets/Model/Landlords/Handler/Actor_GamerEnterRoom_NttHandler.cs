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
                //GameObject matchPrompt = uiRoom.GameObject.Get<GameObject>("MatchPrompt");
                
                uiRoom.GameObject.Get<GameObject>("Ready").SetActive(true);
            }

            //����˷�����3��GamerInfo ������ҽ��뷿���˳��
            int localIndex = -1;
            for (int i = 0; i < message.Gamers.Count; i++)
            {
                if (message.Gamers[i].UserID == LandRoomComponent.LocalGamer.UserID)
                {
                    //�ó���������ǵڼ������뷿�䣬������0,1,2
                    localIndex = i;
                }
            }

            //��ӽ��뷿�����ң��ж���λλ��
            for (int i = 0; i < message.Gamers.Count; i++)
            {
                //�������˷�����Ĭ�Ͽ�GamerInfo ����
                GamerInfo gamerInfo = message.Gamers[i];
                if (gamerInfo.UserID == 0)
                    continue;
                //������ID����Ҳ�������
                if (landRoomComponent.GetGamer(gamerInfo.UserID) == null)
                {
                    Gamer gamer = ETModel.ComponentFactory.Create<Gamer, long>(gamerInfo.UserID);

                    // localIndex + 1 ָ������Һ�������һ�����
                    // ���۱�������ǵڼ������뷿�䣬������1��λ���±ߣ�
                    if ((localIndex + 1) % 3 == i)
                    {
                        //����ڱ�������ұ�2��λ
                        landRoomComponent.AddGamer(gamer, 2);
                    }
                    else
                    {
                        //����ڱ���������0��λ
                        landRoomComponent.AddGamer(gamer, 0);
                    }
                }
            }

            await ETTask.CompletedTask;
        }
    }
}