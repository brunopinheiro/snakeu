using UnityEngine;

namespace SnakeU.GameScene {
    [CreateAssetMenu(fileName = "Board", menuName = "SnakeU/Board", order = 1)]
    public class BoardData: ScriptableObject {
        public Dimensions dimensions;
        public Size blockSize;
        public SnakeData snake;
    }
}