using UnityEngine;

namespace SnakeU.GameScene {
    [ExecuteAlways]
    public class Board: MonoBehaviour {
        public BoardData boardData;
        
        public BoardCoordinates boardCoordinates {
            get;
            private set;
        }

        void Awake() {
            boardCoordinates = new BoardCoordinates(this);
        }
    }
}