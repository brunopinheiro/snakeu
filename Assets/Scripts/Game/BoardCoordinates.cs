using UnityEngine;

namespace SnakeU.GameScene {
    public struct BoardCoordinates {
        Board board;

        public BoardCoordinates(Board board) {
            this.board = board;
        }

        Dimensions boardDimensions {
            get { return board.boardData.dimensions; }
        }

        Size blockSize {
            get { return board.boardData.blockSize; }
        }

        public Vector2 center {
            get {
                // using int cast since I want it to rounds toward zero
                return new Vector2(
                    (int)(boardDimensions.columns * .5f),
                    (int)(boardDimensions.rows * 5f)
                );
            }
        }

        public Vector2 centerPosition {
            get { return board.transform.position; }
        }

        public Vector2 GetPositionForCoordinates(Vector2 coordinates) {
            var horizontalAdjustment = boardDimensions.columns % 2 == 0 ? .5f : 0;
            var verticalAdjustment = boardDimensions.rows % 2 == 0 ? .5f : 0;

            return new Vector2(
                topLeftPosition.x + (coordinates.x + horizontalAdjustment) * blockSize.width,
                topLeftPosition.y + (coordinates.y + verticalAdjustment) * blockSize.height
            );
        }

        Vector2 topLeftPosition {
            get {
                return new Vector2(
                   centerPosition.x - center.x * blockSize.width,
                   centerPosition.y - center.y * blockSize.height
                );
            }
        }
    }
}