using System.Collections.Generic;
using UnityEngine;

namespace ETModel
{
    public static class CardHelper
    {
        //����ͼ��Ԥ������
        public const string ATLAS_NAME = "Atlas";

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="cards"></param>
        public static void Sort(List<Card> cards)
        {
            for (int i = cards.Count; i > 0; i--)
            {
                for (int j = 0; j < i - 1; j++)
                {
                    //�Ȱ���Ȩ�ؽ����ٰ���ɫ����
                    if (-CompareTo((int)cards[j].CardWeight, (int)cards[j + 1].CardWeight) * 2 +
                    CompareTo((int)cards[j].CardSuits, (int)cards[j + 1].CardSuits) > 0)
                    {
                        Card temp = cards[j];
                        cards[j] = cards[j + 1];
                        cards[j + 1] = temp;
                    }
                }
            }
        }

        /// <summary>
        /// int�Ƚ�
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int CompareTo(int a, int b)
        {
            int result;
            if (a > b)
            {
                result = 1;
            }
            else if (a < b)
            {
                result = -1;
            }
            else
            {
                result = 0;
            }
            return result;
        }

        /// <summary>
        /// ��ȡ���ƾ���
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cardName"></param>
        /// <returns></returns>
        public static Sprite GetCardSprite(string cardName)
        {
            GameObject atlas = (GameObject)ETModel.Game.Scene.GetComponent<ResourcesComponent>().GetAsset($"{ATLAS_NAME}.unity3d", ATLAS_NAME);
            return atlas.Get<Sprite>(cardName);
        }
    }
}