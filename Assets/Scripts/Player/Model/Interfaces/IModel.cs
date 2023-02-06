using UnityEngine;

namespace Player.Model.Interfaces
{
    public interface IModel
    {
        Quaternion Rotation { get; }
        Vector3 Position { get; }
        float Health { get; }
        bool IsDead { get; }

        void Move(Vector2 direction);
        void Rotate(Quaternion quaternion, float rotationSpeed);
    }
}