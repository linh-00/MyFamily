namespace Inc.MyFamily.Domain.Entities
{
    public class Parent : BaseEntities
    {
        public string FullName { get; private set; }
        public string NickName { get; private set; }
        public string BiologicalSex { get; private set; }
        public int FamilyId { get; private set; }
        public string Login { get; private set; }
        public string Password { get; private set; }

        public Parent(int id, string fullName, string nickName, string biologicalSex, int familiId, string login, string password) : base(id)
        {
            FullName = fullName;
            NickName = nickName;
            BiologicalSex = biologicalSex;
            FamilyId = familiId;
            Login = login;
            Password = password;
        }
    }
}
