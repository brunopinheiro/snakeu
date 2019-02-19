using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace SnakeU.GameScene {
    [RequireComponent(typeof(Text))]
    [ExecuteAlways]
    public class Scoreboard: MonoBehaviour {
        public string valueMask = "000000";
        int score = 0;
        Text valueText;
        Board board;

        void Awake() {
            InitializeDependencies();
        }

        void InitializeDependencies() {
            if(valueText == null)
                valueText = GetComponent<Text>();

            if(board == null)
                board = GameObject.FindObjectOfType<Board>();
        }

        void Start() {
            if(board != null)
                board.notificationCenter.AddListener(GameEvents.blockCollected, HandleBlockCollected);
        }

        void HandleBlockCollected(Hashtable args) {
            score += 9;
            UpdateScoreText();
        }

        void UpdateScoreText() {
            valueText.text = score.ToString(valueMask);
        }

#if UNITY_EDITOR
        void Update() {
            InitializeDependencies();
            UpdateScoreText();
        }
#endif
    }
}