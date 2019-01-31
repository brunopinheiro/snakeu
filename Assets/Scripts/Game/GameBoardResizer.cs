using UnityEngine;

namespace SnakeU.GameScene {
    [ExecuteAlways]
    public class GameBoardResizer: MonoBehaviour {
        public GameBoard board;

        void Start() {
            ResizeItself();
        }

        void ResizeItself() {
            transform.localScale = CalculateBoardScale();
        }

        Vector3 CalculateBoardScale() {
            return new Vector3(
                board.dimensions.columns * board.blockSize.width,
                board.dimensions.rows * board.blockSize.height,
                transform.localScale.z
            );
        }

#if UNITY_EDITOR
        void Update() {
            ResizeItself();
        }
    }
#endif
}