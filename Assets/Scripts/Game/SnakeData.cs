using UnityEngine;

namespace SnakeU.GameScene {
    [CreateAssetMenu(fileName = "Snake", menuName = "SnakeU/Snake", order = 1)]
    public class SnakeData: ScriptableObject {
        [Range(1, 5)] public int initialSize = 3;
        [Range(1, 9)] public int speed = 1;
        public GameObject childPrefab;
    }
}