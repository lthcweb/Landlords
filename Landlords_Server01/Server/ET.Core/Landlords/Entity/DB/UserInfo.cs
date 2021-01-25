using MongoDB.Bson.Serialization.Attributes;

namespace ETModel
{
    [ObjectSystem]
    public class UserInfoAwakeSystem : AwakeSystem<UserInfo, string>
    {
        public override void Awake(UserInfo self, string name)
        {
            self.Awake(name);
        }
    }

    /// <summary>
    /// 用户信息
    /// </summary>
    public class UserInfo : Entity
    {
        //昵称
        public string UserName { get; set; }

        //等级
        public int Level { get; set; }

        //余额
        public long Money { get; set; }

        //电话
        public long Phone { get; set; }

        //邮箱
        public string Email { get; set; }

        //性别
        public string Sex { get; set; }

        //称号
        public string Title { get; set; }

        public int LastPlay { get; set; }

        //public List<Ca>
        public void Awake(string name)
        {
            UserName = name;
            Level = 1;
            Money = 10000;
            Title = "贫农";
            Email = "";
            Sex = "";
            LastPlay = 0;
        }
    }
}
