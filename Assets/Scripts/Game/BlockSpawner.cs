using System.Collections;
using UnityEngine;

namespace SnakeU.GameScene {
    public class BlockSpawner: MonoBehaviour {
        public GameObject blockPrefab;
        Board board;

        void Awake() {
            board = GameObject.FindObjectOfType<Board>();

            board.notificationCenter.AddListener("board.firstBlockRequested", SpawnObject);
            board.notificationCenter.AddListener("snake.blockCollected", SpawnObject);
        }

        void OnDestroy() {
            board.notificationCenter.RemoveListener("board.firstBlockRequested", SpawnObject);
            board.notificationCenter.RemoveListener("snake.blockCollected", SpawnObject);
        }

        void SpawnObject(Hashtable args) {
            var newCoordinates = board.boardCoordinates.GetRandomAvailableCoordinates();
            var newBlock = GameObject.Instantiate(blockPrefab);
            newBlock.transform.localScale = board.boardData.blockSize;
            newBlock.transform.position = board.boardCoordinates.GetPositionForCoordinates(newCoordinates);
            newBlock.transform.SetParent(transform, true);
        }
    }
}