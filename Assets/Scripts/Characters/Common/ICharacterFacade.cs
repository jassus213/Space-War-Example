using UnityEngine;

namespace Characters.Common
{
    public interface ICharacterFacade
    {
        Rigidbody2D Rigidbody { get; }
        Transform Position { get; }
    }
}