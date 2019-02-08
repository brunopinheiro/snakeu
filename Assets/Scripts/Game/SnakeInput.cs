using UnityEngine;
using System.Collections.Generic;

namespace SnakeU.GameScene {
    public class SnakeInput: MonoBehaviour {
        static string HorizontalInput = "Horizontal";
        static string VerticalInput = "Vertical";
        Dictionary<string, int> previousInputs = new Dictionary<string, int>();

        void Update() {
            if(CheckInput(HorizontalInput)) {
                previousInputs[VerticalInput] = 0;
            } else {
                previousInputs[HorizontalInput] = 0;
                CheckInput(VerticalInput);
            }
        }

        bool CheckInput(string direction) {
            var inputAxis = Input.GetAxisRaw(direction);
            if(inputAxis == 0) {
                previousInputs[direction] = 0;
                return false;
            }

            var previousInputAxis = previousInputs[direction];
            if(inputAxis == previousInputAxis) {
                return false;
            }

            var message = string.Empty;
            if(direction == HorizontalInput) {
                message = inputAxis > 0 ? "TryMoveRight" : "TryMoveLeft";
            } else if(direction == VerticalInput) {
                message = inputAxis > 0 ? "TryMoveUp" : "TryMoveDown";
            }

            previousInputs[direction] = (int)inputAxis;
            SendMessage(message);
            return true;
        }
    }
}