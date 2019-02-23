using System.Collections;
using UnityEngine;

namespace SnakeU.GameScene {
    [RequireComponent(typeof(Snake))]
    public class SnakeCreator: MonoBehaviour {
        Snake snake;
        static Vector2 growthDirection = Vector2.left;

        void Awake() {
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
                CreateChildAt(childCoordinates);
            }
        }

        public SnakeChild CreateChildAt(Vector2 coordinates) {
            var child = GameObject.Instantiate<SnakeChild>(snake.snakeData.childPrefab, transform);
            child.transform.localScale = snake.blockSize;
            child.transform.position = snake.boardCoordinates.GetPositionForCoordinates(coordinates);
            child.coordinates = coordinates;

            snake.EmitOccupationEvent(
                GameEvents.coordinateOccupied,
                coordinates,
                child.gameObject
            );

            return child;
        }
    }
}
