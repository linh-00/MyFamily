namespace Inc.MyFamily.Domain.Entities
{
    public abstract class BaseEntities
    {
        public int Id { get; private set; }

        protected BaseEntities(int id)
        {
            Id = id;
        }

        protected BaseEntities()
        {

        }

        public void setId(int id)
        {
            Id = id;
        }
    }
}
