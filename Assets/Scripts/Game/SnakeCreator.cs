using UnityEngine;

namespace SnakeU.GameScene {
    [RequireComponent(typeof(Snake))]
    [ExecuteAlways]
    public class SnakeCreator: MonoBehaviour {
        Snake snake;
        static Vector2 growthDirection = Vector2.left;

        void Awake() {
            snake = GetComponent<Snake>();
        }

        void Start() {
            snake.transform.position = snake.boardCoordinates.centerPosition;
            snake.headCoordinates = snake.boardCoordinates.center;
            ClearChildren();
            CreateInitialChildren();
        }

        void ClearChildren() {
            for(int i = snake.transform.childCount - 1; i >= 0; i--) {
                GameObject.DestroyImmediate(snake.transform.GetChild(i).gameObject);
            }
        }

        void CreateInitialChildren() {
            for(int i = 0; i < snake.snakeData.initialSize; i++) {
                var child = GameObject.Instantiate(snake.snakeData.childPrefab, snake.transform);
                var childCoordinates = snake.headCoordinates + growthDirection * i;
                child.transform.localScale = snake.blockSize;
                child.transform.position = snake.boardCoordinates.GetPositionForCoordinates(childCoordinates);
                child.transform.SetParent(snake.transform, true);
            }
        }

#if UNITY_EDITOR
        void Update() {
            if(snake == null || snake.board == null)
                return;

            if(snake.transform.childCount != snake.snakeData.initialSize) {
                ClearChildren();
                CreateInitialChildren();
            }
        }
#endif
    }
}