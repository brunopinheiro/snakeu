using System;
using UnityEngine;

namespace SnakeU.GameScene {
    public class SnakeCollision {
        Action<Vector2> emptySpaceHandler;
        Action<Vector2, GameObject> blockHitHandler;
        Action snakeHitHandler;
        Vector2 coordinates;
        GameObject coordinatesOccupier;

        public SnakeCollision(Vector2 coordinates, GameObject coordinatesOccupier) {
            this.coordinates = coordinates;
            this.coordinatesOccupier = coordinatesOccupier;
        }

        public SnakeCollision CaseEmptySpace(Action<Vector2> emptySpaceHandler) {
            this.emptySpaceHandler = emptySpaceHandler;
            return this;
        }

        public SnakeCollision CaseHitSnake(Action snakeHitHandler) {
            this.snakeHitHandler = snakeHitHandler;
            return this;
        }

        public SnakeCollision CaseHitBlock(Action<Vector2, GameObject> blockHitHandler) {
            this.blockHitHandler = blockHitHandler;
            return this;
        }

        public void Execute() {
            if(coordinatesOccupier == null) {
                emptySpaceHandler.Invoke(coordinates);
                return;
            }

            var colliderLayer = LayerMask.LayerToName(coordinatesOccupier.layer);
            switch(colliderLayer) {
                case "Snake": snakeHitHandler.Invoke(); break;
                case "Block": blockHitHandler.Invoke(coordinates, coordinatesOccupier); break;
                default: emptySpaceHandler.Invoke(coordinates); break;
            }
        }
    }
}