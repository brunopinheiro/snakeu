using UnityEngine;

namespace SnakeU.GameScene {
    [ExecuteAlways]
    public class Board: MonoBehaviour {
        public BoardData boardData;
        
        public BoardCoordinates boardCoordinates {
            get { return new BoardCoordinates(this); }
        }
    }
}