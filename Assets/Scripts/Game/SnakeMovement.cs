using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SnakeU.GameScene {
    [RequireComponent(typeof(Snake))]
    public class SnakeMovement: MonoBehaviour {
        enum Direction {
            Up, Right, Down, Left
        }

        Snake snake;
        Direction direction = Direction.Right;
        Direction nextDirection = Direction.Right;
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
            MoveInDirection(direction);
            direction = nextDirection;
            StartMoveCoroutine();
        }

        void MoveInDirection(Direction direction) {
            var directionVector = GetMovementVectorFrom(direction);
            var tail = snake.transform.GetChild(transform.childCount - 1).GetComponent<SnakeChild>();
            var previousCoordinate = tail.coordinates;
            tail.transform.SetAsFirstSibling();
            snake.headCoordinates += directionVector;
            tail.transform.position = snake.boardCoordinates.GetPositionForCoordinates(snake.headCoordinates);

            snake.EmitOccupationEvent(GameEvents.coordinateOccupied, snake.headCoordinates, tail.gameObject);
            snake.EmitOccupationEvent(GameEvents.coordinateDisoccupied, previousCoordinate);
        }

        Vector2 GetMovementVectorFrom(Direction direction) {
            Vector2 movement = Vector2.right;
            switch(direction) {
                case Direction.Up: movement =  Vector2.up; break;
                case Direction.Down: movement = Vector2.down; break;
                case Direction.Left: movement = Vector2.left; break;
                case Direction.Right: movement = Vector2.right; break;
            }
            return movement;
        }

        void TryMoveUp() {
            TryMoveInDirection(Direction.Up);
        }

        Direction GetOppositeDirection(Direction direction) {
            Direction opposite = Direction.Up;
            switch(direction) {
                case Direction.Up: opposite = Direction.Down; break;
                case Direction.Down: opposite = Direction.Up; break;
                case Direction.Left: opposite = Direction.Right; break;
                case Direction.Right: opposite = Direction.Left; break;
            }
            return opposite;
        }

        void TryMoveInDirection(Direction targetDirection) {
            if(direction != GetOppositeDirection(targetDirection))
                nextDirection = targetDirection;
        }

        void TryMoveDown() {
            TryMoveInDirection(Direction.Down);
        }

        void TryMoveLeft() {
            TryMoveInDirection(Direction.Left);
        }

        void TryMoveRight() {
            TryMoveInDirection(Direction.Right);
        }
    }
}