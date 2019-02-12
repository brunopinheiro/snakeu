using UnityEngine;

namespace SnakeU.GameScene {
    public class Board: MonoBehaviour {
        public BoardData boardData;

        public NotificationCenter notificationCenter {
            get; private set;
        }

        public BoardMapper boardMapper {
            get; private set;
        }

        public BoardCoordinates boardCoordinates {
            get { return new BoardCoordinates(this); }
        }

        void Awake() {
            notificationCenter = new NotificationCenter();
            boardMapper = new BoardMapper();
        }

        void Start() {
            boardMapper.StartListeningEventsFrom(notificationCenter);

            notificationCenter.EmitEvent("board.firstBlockRequested");
        }
    }
}