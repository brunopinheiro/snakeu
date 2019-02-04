using System.Collections;
using UnityEngine;

namespace SnakeU.GameScene {
    [RequireComponent(typeof(Snake))]
    public class SnakeMovement: MonoBehaviour {
        Snake snake;
        Vector2 direction = Vector2.right;
        Coroutine movementCoroutine;

        void Awake() {
            snake = GetComponent<Snake>();
        }

        void Start() {
            StartMoveCoroutine();
        }

        void StartMoveCoroutine() {
            movementCoroutine = StartCoroutine(Move());
        }

        IEnumerator Move() {
            var movementDelay = 1 - snake.snakeData.speed * .1f;
            yield return new WaitForSeconds(movementDelay);
            snake.MoveInDirection(direction);
            StartMoveCoroutine();
        }
    }
}