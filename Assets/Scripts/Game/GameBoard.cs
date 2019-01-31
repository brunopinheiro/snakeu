using UnityEngine;

namespace SnakeU.GameScene {
    [CreateAssetMenu(fileName = "GameBoard", menuName = "Snake/GameBoard", order = 1)]
    public class GameBoard: ScriptableObject {
        public Dimensions dimensions;
        public Size blockSize;
    }
}