﻿namespace Characters.Player.Input
{
    public class InputState
    {
        public float AxisRawVertical { get; set; }
        public float AxisRawHorizontal { get; set; }
        public bool IsFiring { get; set; }
        public bool IsAccelerating { get; set; }
    }
}