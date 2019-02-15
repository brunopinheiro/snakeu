using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityRandom = UnityEngine.Random;

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

        public BoardMapper boardMapper {
            get { return board.boardMapper; }
        }

        public Vector2 center {
            get {
                // using int cast since I want it to rounds toward zero
                return new Vector2(
                    (int)(boardDimensions.columns * .5f),
                    (int)(boardDimensions.rows * .5f)
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
                bottomLeftPosition.x + (coordinates.x + horizontalAdjustment) * blockSize.width,
                bottomLeftPosition.y + (coordinates.y + verticalAdjustment) * blockSize.height
            );
        }

        Vector2 bottomLeftPosition {
            get {
                return new Vector2(
                   centerPosition.x - center.x * blockSize.width,
                   centerPosition.y - center.y * blockSize.height
                );
            }
        }

        public Vector2 GetRandomAvailableCoordinates() {
            var availableCoordinates = GetAvailableCoordinates();
            return availableCoordinates[(int)UnityRandom.Range(0, availableCoordinates.Length - 1)];
        }

        Vector2[] GetAvailableCoordinates() {
            var allCoordinates = new List<Vector2>();
            for(int col = 0; col < boardDimensions.columns; col++) {
                for(int row = 0; row < boardDimensions.rows; row++) {
                    allCoordinates.Add(new Vector2(col, row));
                }
            }

            return allCoordinates.Except(boardMapper.OccupiedCoordinates).ToArray();
        }

        public bool BelongsToBoard(Vector2 coordinates) {
            return coordinates.x >= 0 &&
            coordinates.y >= 0 &&
            coordinates.x < boardDimensions.columns && 
            coordinates.y < boardDimensions.rows;
        }
    }
}