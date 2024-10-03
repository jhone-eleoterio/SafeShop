namespace SafeShopAPI.Domain
{
    public class Entity
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; } = null;
        public bool IsActive { get; private set; }

        public Entity()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.Now;
            IsActive = true;
        }
    }
}
