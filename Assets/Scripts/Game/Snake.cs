using System.Collections;
using UnityEngine;

namespace SnakeU.GameScene {
    [ExecuteAlways]
    public class Snake: MonoBehaviour {
        public Board board {
            get;
            private set;
        }
        
        [HideInInspector] public Vector2 headCoordinates;

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

        NotificationCenter boardNotificationCenter {
            get { return board.notificationCenter; }
        }

        void Awake() {
            InitializeDependencies();
        }

        void InitializeDependencies() {
            if(board == null)
                board = GameObject.FindObjectOfType<Board>();
        }

#if UNITY_EDITOR
        void Update() {
            InitializeDependencies();
        }
#endif

        public void AddChildWithCoordinates(Vector2 coordinates) {
            var child = GameObject.Instantiate<SnakeChild>(snakeData.childPrefab, transform);
            child.transform.localScale = blockSize;
            child.transform.position = boardCoordinates.GetPositionForCoordinates(coordinates);
            child.transform.SetParent(transform, true);
            child.coordinates = coordinates;
            EmitOccupationEvent(GameEvents.coordinateOccupied, coordinates);
        }

        void EmitOccupationEvent(string eventName, Vector2 coordinates) {
            if(board == null || board.notificationCenter == null)
                return;

            boardNotificationCenter.EmitEvent(eventName, new Hashtable() {
                { "coordinates", coordinates }
            });
        }

        public void MoveInDirection(Vector2 direction) {
            var tail = transform.GetChild(transform.childCount - 1).GetComponent<SnakeChild>();
            var previousCoordinate = tail.coordinates;
            tail.transform.SetAsFirstSibling();
            headCoordinates += direction;
            tail.transform.position = boardCoordinates.GetPositionForCoordinates(headCoordinates);

            EmitOccupationEvent(GameEvents.coordinateOccupied, headCoordinates);
            EmitOccupationEvent(GameEvents.coordinateDisoccupied, previousCoordinate);
        }
    }
}