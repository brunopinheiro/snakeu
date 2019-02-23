using System.Collections;
using UnityEngine;

namespace SnakeU.GameScene {
    public class BlockSpawner: MonoBehaviour {
        public GameObject blockPrefab;
        Board board;

        void Awake() {
            board = GameObject.FindObjectOfType<Board>();
        }

        void Start() {
            board.notificationCenter.AddListener(GameEvents.gameStart, HandleGameStart);
            board.notificationCenter.AddListener(GameEvents.blockCollected, SpawnObject);
        }

        void HandleGameStart(Hashtable arguments) {
            for(int i = transform.childCount - 1; i >= 0; i--) {
                GameObject.DestroyImmediate(transform.GetChild(i).gameObject);
            }
            SpawnObject(new Hashtable());
        }

        void SpawnObject(Hashtable args) {
            var newCoordinates = board.boardCoordinates.GetRandomAvailableCoordinates();
            var newBlock = GameObject.Instantiate(blockPrefab);
            newBlock.transform.localScale = board.boardData.blockSize;
            newBlock.transform.position = board.boardCoordinates.GetPositionForCoordinates(newCoordinates);
            newBlock.transform.SetParent(transform, true);

            board.notificationCenter.EmitEvent(GameEvents.coordinateOccupied, new Hashtable() {
                { "coordinates", newCoordinates },
                { "occupier", newBlock }
            });
        }
    }
}
