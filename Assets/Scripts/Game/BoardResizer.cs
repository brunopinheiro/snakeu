using UnityEngine;

namespace SnakeU.GameScene {
    [ExecuteAlways]
    public class BoardResizer: MonoBehaviour {
        public BoardData boardData;

        void Start() {
            ResizeItself();
        }

        void ResizeItself() {
            transform.localScale = CalculateBoardScale();
        }

        Vector3 CalculateBoardScale() {
            return new Vector3(
                boardData.dimensions.columns * boardData.blockSize.width,
                boardData.dimensions.rows * boardData.blockSize.height,
                transform.localScale.z
            );
        }

#if UNITY_EDITOR
        void Update() {
            // during edit mode, it is possible that you didn't set board field yet
            // this conditional avoids getting a NullException error message
            if(boardData != null)
                ResizeItself();
        }
    }
#endif
}