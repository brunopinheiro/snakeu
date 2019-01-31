using UnityEngine;

namespace SnakeU.GameScene {
    [CreateAssetMenu(fileName = "Board", menuName = "Snake/Board", order = 1)]
    public class Board: ScriptableObject {
        public Dimensions dimensions;
        public Size blockSize;
    }
}