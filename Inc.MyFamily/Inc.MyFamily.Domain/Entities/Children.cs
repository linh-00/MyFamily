namespace Inc.MyFamily.Domain.Entities
{
    public class Children : BaseEntities
    {
        public string Name { get; private set; }
        public string BiologicalSex { get; private set; }
        public string Login { get; private set; }
        public string Password { get; private set; }
        public int FamilyId { get; private set; }

        public Children(int id, string name, string biologicalSex, string login, string password, int familyId) : base(id)
        {
            Name = name;
            BiologicalSex = biologicalSex;
            Login = login;
            Password = password;
            FamilyId = familyId;
        }
    }
}
