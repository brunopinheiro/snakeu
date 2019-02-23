using System.Collections;
using UnityEngine;

namespace SnakeU.GameScene {
    public class StartButton: MonoBehaviour {
        Board board;

        void Awake() {
            board = GameObject.FindObjectOfType<Board>();
        }

        void Start() {
            board.notificationCenter.AddListener(GameEvents.gameStart, HandleGameStart);
            board.notificationCenter.AddListener(GameEvents.gameStop, HandleGameStop);
        }

        void HandleGameStart(Hashtable arguments) {
            gameObject.SetActive(false);
        }

        void HandleGameStop(Hashtable arguments) {
            gameObject.SetActive(true);
        }

        public void StartGame() {
            board.notificationCenter.EmitEvent(GameEvents.gameStart);
        }
    }
}
