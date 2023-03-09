using UnityEngine;

namespace Characters.Player.Model.Interfaces
{
    public interface IMovable
    {
        void Move(Vector2 goalPos);
        void Rotate(Quaternion quaternion, float rotationSpeed);
    }
}