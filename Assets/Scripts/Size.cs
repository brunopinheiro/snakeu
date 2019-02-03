using System;
using UnityEngine;

namespace SnakeU {
    [Serializable] public struct Size {
        public float width;
        public float height;

        public static implicit operator Vector2(Size size) {
            return new Vector2(size.width, size.height);
        }

        public static implicit operator Vector3(Size size) {
            return new Vector3(size.width, size.height, 1);
        }
    }
}