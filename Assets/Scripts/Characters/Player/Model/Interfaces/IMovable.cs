using UnityEngine;

namespace Characters.Player.Model.Interfaces
{
    public interface IMovable
    {
        Quaternion Rotation { get; }
        Vector3 Position { get; }
        void Move(Vector2 goalPos);
        void Rotate(Quaternion quaternion, float rotationSpeed);
    }
}