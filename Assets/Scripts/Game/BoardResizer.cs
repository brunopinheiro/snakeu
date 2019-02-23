using UnityEngine;

namespace SnakeU.GameScene {
    [ExecuteAlways]
    [RequireComponent(typeof(Board))]
    public class BoardResizer: MonoBehaviour {
        Board board;

        void Awake() {
            InitializeDependencies();
            ResizeItself();
        }

        void InitializeDependencies() {
            if(board != null)
                return;

            board = GetComponent<Board>();
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

        BoardData boardData {
            get { return board.boardData ?? null; }
        }

#if UNITY_EDITOR
        void Update() {
            if(UnityEditor.EditorApplication.isPlaying)
                return;

            InitializeDependencies();

            // during edit mode, it is possible that you didn't set board field yet
            // this conditional avoids getting a NullException error message
            if(boardData != null)
                ResizeItself();
        }
    }
#endif
}
