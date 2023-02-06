using UnityEngine;
using Zenject;

namespace Player.InputHandler
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
            _inputState.AxisRawHorizontal = Input.GetAxisRaw("Horizontal");
            _inputState.AxisRawVertical = Input.GetAxisRaw("Vertical");
            _inputState.IsFiring = Input.GetMouseButton(0);
        }
    }
}