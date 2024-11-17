namespace Inc.MyFamily.Domain.Entities
{
    public class Family : BaseEntities
    {
        public string SurName { get; private set; }
        public bool? Status { get; private set; }

        public Family(int id, string surName, bool? status) : base(id)
        {
            SurName = surName;
            Status = status;
        }
    }
}
