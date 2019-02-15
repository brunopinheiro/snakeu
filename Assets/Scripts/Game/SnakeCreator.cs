using System.Collections;
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
                var headCoordinates = i == 0 ? snake.boardCoordinates.center : snake.GetHead().coordinates;
                var childCoordinates = headCoordinates + growthDirection * i;

                var child = GameObject.Instantiate<SnakeChild>(snake.snakeData.childPrefab, transform);
                child.transform.localScale = snake.blockSize;
                child.transform.position = snake.boardCoordinates.GetPositionForCoordinates(childCoordinates);
                child.transform.SetParent(transform, true);
                child.coordinates = childCoordinates;

                snake.EmitOccupationEvent(
                    GameEvents.coordinateOccupied,
                    childCoordinates,
                    child.gameObject
                );
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