namespace Characters.Player.Model.Interfaces
{
    public interface IModel
    {
        float Health { get; }
        void TakeDamage(float damage);
    }
}