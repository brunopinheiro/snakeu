using UnityEngine;

namespace SnakeU.GameScene {
    [ExecuteAlways]
    public class BoardResizer: MonoBehaviour {
        public Board board;

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
            // during edit mode, it is possible that you didn't set board field yet
            // this conditional avoids getting a NullException error message
            if(board != null)
                ResizeItself();
        }
    }
#endif
}