using System.Collections;
using UnityEngine;

namespace SnakeU.GameScene {
    public class Snake: MonoBehaviour {
        public Board board {
            get;
            private set;
        }

        SnakeCreator snakeCreator;

        public BoardCoordinates boardCoordinates {
            get { return board.boardCoordinates; }
        }

        public Dimensions boardDimensions {
            get { return board.boardData.dimensions; }
        }

        public Size blockSize {
            get { return board.boardData.blockSize; }
        }

        public SnakeData snakeData {
            get { return board.boardData.snake; }
        }

        public NotificationCenter boardNotificationCenter {
            get { return board.notificationCenter; }
        }

        public BoardMapper boardMapper {
            get { return board.boardMapper; }
        }

        public SnakeChild GetTail() {
            return transform.GetChild(transform.childCount - 1).GetComponent<SnakeChild>();
        }

        public SnakeChild GetHead() {
            return transform.GetChild(0).GetComponent<SnakeChild>();
        }

        void Awake() {
            board = GameObject.FindObjectOfType<Board>();
            snakeCreator = GetComponent<SnakeCreator>();
        }

        public void EmitOccupationEvent(string eventName, Vector2 coordinates, GameObject occupier = null) {
            if(board == null || board.notificationCenter == null)
                return;

            var arguments =  new Hashtable() {
                { "coordinates", coordinates }
            };

            if(occupier != null) {
                arguments.Add("occupier", occupier);
            }

            boardNotificationCenter.EmitEvent(eventName, arguments);
        }

        public void CollectBlock(Vector2 coordinates, GameObject block) {
            GameObject.Destroy(block);
            snakeCreator.CreateChildAt(coordinates).transform.SetAsFirstSibling();
            boardNotificationCenter.EmitEvent(GameEvents.blockCollected);
        }

        public void HandleHitItself() {
            boardNotificationCenter.EmitEvent(GameEvents.gameStop, new Hashtable());
        }

        public void HandleOutOfBoard() {
            boardNotificationCenter.EmitEvent(GameEvents.gameStop, new Hashtable());
        }
    }
}
