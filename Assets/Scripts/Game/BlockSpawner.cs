using System.Collections;
using UnityEngine;

namespace SnakeU.GameScene {
    public class BlockSpawner: MonoBehaviour {
        public GameObject blockPrefab;
        Board board;

        void Awake() {
            board = GameObject.FindObjectOfType<Board>();

            board.notificationCenter.AddListener(GameEvents.firstBlockRequested, SpawnObject);
            board.notificationCenter.AddListener(GameEvents.blockCollected, SpawnObject);
        }

        void OnDestroy() {
            board.notificationCenter.RemoveListener(GameEvents.firstBlockRequested, SpawnObject);
            board.notificationCenter.RemoveListener(GameEvents.blockCollected, SpawnObject);
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