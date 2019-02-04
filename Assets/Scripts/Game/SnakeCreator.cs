using UnityEngine;

namespace SnakeU.GameScene {
    [RequireComponent(typeof(Snake))]
    [ExecuteAlways]
    public class SnakeCreator: MonoBehaviour {
        Snake snake;
        static Vector2 growthDirection = Vector2.left;

        void Awake() {
            InitializeDependencies();
        }

        void InitializeDependencies() {
            if(snake != null)
                return;

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
                var childCoordinates = snake.headCoordinates + growthDirection * i;
                snake.AddChildWithCoordinates(childCoordinates);
            }
        }

#if UNITY_EDITOR
        void Update() {
            InitializeDependencies();

            if(snake.transform.childCount != snake.snakeData.initialSize) {
                ClearChildren();
                CreateInitialChildren();
            }
        }
#endif
    }
}