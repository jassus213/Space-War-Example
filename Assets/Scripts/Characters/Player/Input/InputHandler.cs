using UnityEngine;
using Zenject;

namespace Characters.Player.Input
{
    public class InputHandler : IFixedTickable
    {
        private readonly InputState _inputState;

        public InputHandler(InputState inputState)
        {
            _inputState = inputState;
        }
        
        public void FixedTick()
        {
            _inputState.AxisRawHorizontal = UnityEngine.Input.GetAxisRaw("Horizontal");
            _inputState.AxisRawVertical = UnityEngine.Input.GetAxisRaw("Vertical");
            _inputState.IsFiring = UnityEngine.Input.GetMouseButton(0);
            _inputState.IsAccelerating = UnityEngine.Input.GetKey(KeyCode.LeftShift);
        }
    }
}