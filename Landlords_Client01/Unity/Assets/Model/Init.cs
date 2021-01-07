using System;
using System.Threading;
using UnityEngine;

namespace ETModel
{
	public class Init : MonoBehaviour
	{
		private void Start()
		{
			this.StartAsync().Coroutine();
		}
		
		private async ETVoid StartAsync()
		{
			try
			{
				SynchronizationContext.SetSynchronizationContext(OneThreadSynchronizationContext.Instance);

				DontDestroyOnLoad(gameObject);
				ClientConfigHelper.SetConfigHelper();
				Game.EventSystem.Add(DLLType.Core, typeof(Core).Assembly);
				Game.EventSystem.Add(DLLType.Model, typeof(Init).Assembly);

				Game.Scene.AddComponent<GlobalConfigComponent>();
				Game.Scene.AddComponent<ResourcesComponent>();

				ETModel.Game.Scene.GetComponent<ResourcesComponent>().LoadBundle("config.unity3d");
				Game.Scene.AddComponent<ConfigComponent>();
				ETModel.Game.Scene.GetComponent<ResourcesComponent>().UnloadBundle("config.unity3d");

				UnitConfig unitConfig = (UnitConfig)Game.Scene.GetComponent<ConfigComponent>().Get(typeof(UnitConfig), 1001);
				Log.Debug($"config {JsonHelper.ToJson(unitConfig)}");


				//添加指定与网络组件
				Game.Scene.AddComponent<OpcodeTypeComponent>();
				Game.Scene.AddComponent<NetOuterComponent>();


				//添加UI组件
				Game.Scene.AddComponent<UIComponent>();
				Game.Scene.AddComponent<GamerComponent>();

				//添加消息分发组件MessageDispatcherComponent
				Game.Scene.AddComponent<MessageDispatcherComponent>();

				//Test05
				//练习1
				/*
				Game.Scene.AddComponent<OpcodeTestComponent>();

				Game.Scene.AddComponent<TimerComponent>();
				Game.Scene.AddComponent<FrameTestComponent>();

				Game.EventSystem.Load();
				
				//Test09
				//练习1
				Game.Scene.AddComponent<Test0901Component>();
				Game.EventSystem.Run(UIEventType.EndLandLogin);
				*/


				//执行斗地主初始事件，也就是创建LandLogin界面
				Game.EventSystem.Run(UIEventType.LandInitSceneStart);

				



				//测试发送给服务端一条文本消息
				//Session session = Game.Scene.GetComponent<NetOuterComponent>().Create(GlobalConfigComponent.Instance.GlobalProto.Address);
                //G2C_TestMessage g2CTestMessage = (G2C_TestMessage) await session.Call(new C2G_TestMessage() { Info = "==>>服务端的朋友,你好!收到请回答" });

				
			}
			catch (Exception e)
			{
				Log.Error(e);
			}
		}

		private void Update()
		{
			OneThreadSynchronizationContext.Instance.Update();
			Game.EventSystem.Update();
		}

		private void LateUpdate()
		{
			Game.EventSystem.LateUpdate();
		}

		private void OnApplicationQuit()
		{
			Game.Close();
		}
	}
}