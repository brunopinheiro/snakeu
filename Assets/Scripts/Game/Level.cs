using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace SnakeU.GameScene {
    [RequireComponent(typeof(Text))]
    public class Level: MonoBehaviour {
        Text levelText;
        Board board;

        void Awake() {
            levelText = GetComponent<Text>();
            board = GameObject.FindObjectOfType<Board>();
        }

        void Start() {
            board.notificationCenter.AddListener(GameEvents.speedUpdated, HandleSpeedUpdated);
        }

        void HandleSpeedUpdated(Hashtable arguments){
            var speed = (int)arguments["speed"];
            levelText.text = speed.ToString();
        }
    }
}