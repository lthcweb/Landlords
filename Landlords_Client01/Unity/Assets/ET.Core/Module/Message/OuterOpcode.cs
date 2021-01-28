using ETModel;
namespace ETModel
{
//��ȡ�����������Ϣ����
	[Message(OuterOpcode.C2G_GetUserInfoInRoom_Req)]
	public partial class C2G_GetUserInfoInRoom_Req : IRequest {}

//��ȡ�����������Ϣ����
	[Message(OuterOpcode.G2C_GetUserInfoInRoom_Back)]
	public partial class G2C_GetUserInfoInRoom_Back : IResponse {}

//������Ϣ
	[Message(OuterOpcode.Card)]
	public partial class Card {}

//�Ʒ�ֵ��Ϣ
	[Message(OuterOpcode.GamerCardNum)]
	public partial class GamerCardNum {}

//��Ϸ��ʼ���������Ϣ
	[Message(OuterOpcode.Actor_GameStartHandCards_Ntt)]
	public partial class Actor_GameStartHandCards_Ntt : IActorMessage {}

//��Ϸ�����ٿ���Ϣ=====>
	[Message(OuterOpcode.Actor_GamerPlayCard_Req)]
	public partial class Actor_GamerPlayCard_Req : IActorRequest {}

	[Message(OuterOpcode.Actor_GamerPlayCard_Back)]
	public partial class Actor_GamerPlayCard_Back : IActorResponse {}

	[Message(OuterOpcode.Actor_GamerDontPlayCard_Ntt)]
	public partial class Actor_GamerDontPlayCard_Ntt : IActorMessage {}

	[Message(OuterOpcode.Actor_GamerPrompt_Req)]
	public partial class Actor_GamerPrompt_Req : IActorRequest {}

	[Message(OuterOpcode.Actor_GamerPrompt_Back)]
	public partial class Actor_GamerPrompt_Back : IActorResponse {}

//��ʼ��������Ϣ
	[Message(OuterOpcode.Actor_AuthorityGrabLandlord_Ntt)]
	public partial class Actor_AuthorityGrabLandlord_Ntt : IActorMessage {}

//ѡ�����ط���Ϣ
	[Message(OuterOpcode.Actor_GamerGrabLandlordSelect_Ntt)]
	public partial class Actor_GamerGrabLandlordSelect_Ntt : IActorMessage {}

//���õ�����Ϣ
	[Message(OuterOpcode.Actor_SetLandlord_Ntt)]
	public partial class Actor_SetLandlord_Ntt : IActorMessage {}

//----ET
	[Message(OuterOpcode.Actor_Test)]
	public partial class Actor_Test : IActorMessage {}

	[Message(OuterOpcode.C2M_TestRequest)]
	public partial class C2M_TestRequest : IActorLocationRequest {}

	[Message(OuterOpcode.M2C_TestResponse)]
	public partial class M2C_TestResponse : IActorLocationResponse {}

	[Message(OuterOpcode.Actor_TransferRequest)]
	public partial class Actor_TransferRequest : IActorLocationRequest {}

	[Message(OuterOpcode.Actor_TransferResponse)]
	public partial class Actor_TransferResponse : IActorLocationResponse {}

	[Message(OuterOpcode.C2G_EnterMap)]
	public partial class C2G_EnterMap : IRequest {}

	[Message(OuterOpcode.G2C_EnterMap)]
	public partial class G2C_EnterMap : IResponse {}

	[Message(OuterOpcode.UnitInfo)]
	public partial class UnitInfo {}

	[Message(OuterOpcode.M2C_CreateUnits)]
	public partial class M2C_CreateUnits : IActorMessage {}

	[Message(OuterOpcode.Frame_ClickMap)]
	public partial class Frame_ClickMap : IActorLocationMessage {}

	[Message(OuterOpcode.M2C_PathfindingResult)]
	public partial class M2C_PathfindingResult : IActorMessage {}

	[Message(OuterOpcode.C2R_Ping)]
	public partial class C2R_Ping : IRequest {}

	[Message(OuterOpcode.R2C_Ping)]
	public partial class R2C_Ping : IResponse {}

	[Message(OuterOpcode.G2C_Test)]
	public partial class G2C_Test : IMessage {}

	[Message(OuterOpcode.C2M_Reload)]
	public partial class C2M_Reload : IRequest {}

	[Message(OuterOpcode.M2C_Reload)]
	public partial class M2C_Reload : IResponse {}

}
namespace ETModel
{
	public static partial class OuterOpcode
	{
		 public const ushort C2G_GetUserInfoInRoom_Req = 101;
		 public const ushort G2C_GetUserInfoInRoom_Back = 102;
		 public const ushort Card = 103;
		 public const ushort GamerCardNum = 104;
		 public const ushort Actor_GameStartHandCards_Ntt = 105;
		 public const ushort Actor_GamerPlayCard_Req = 106;
		 public const ushort Actor_GamerPlayCard_Back = 107;
		 public const ushort Actor_GamerDontPlayCard_Ntt = 108;
		 public const ushort Actor_GamerPrompt_Req = 109;
		 public const ushort Actor_GamerPrompt_Back = 110;
		 public const ushort Actor_AuthorityGrabLandlord_Ntt = 111;
		 public const ushort Actor_GamerGrabLandlordSelect_Ntt = 112;
		 public const ushort Actor_SetLandlord_Ntt = 113;
		 public const ushort Actor_Test = 114;
		 public const ushort C2M_TestRequest = 115;
		 public const ushort M2C_TestResponse = 116;
		 public const ushort Actor_TransferRequest = 117;
		 public const ushort Actor_TransferResponse = 118;
		 public const ushort C2G_EnterMap = 119;
		 public const ushort G2C_EnterMap = 120;
		 public const ushort UnitInfo = 121;
		 public const ushort M2C_CreateUnits = 122;
		 public const ushort Frame_ClickMap = 123;
		 public const ushort M2C_PathfindingResult = 124;
		 public const ushort C2R_Ping = 125;
		 public const ushort R2C_Ping = 126;
		 public const ushort G2C_Test = 127;
		 public const ushort C2M_Reload = 128;
		 public const ushort M2C_Reload = 129;
	}
}
