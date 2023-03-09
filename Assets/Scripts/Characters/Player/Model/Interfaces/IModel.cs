using UnityEngine;

namespace Characters.Player.Model.Interfaces
{
    public interface IModel
    {
        Quaternion Rotation { get; }
        Vector3 Position { get; }
        float Health { get; }
        bool IsDead { get; }
        void TakeDamage(float damage);
    }
}