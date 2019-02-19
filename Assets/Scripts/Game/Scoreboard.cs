using UnityEngine;
using UnityEngine.UI;

namespace SnakeU.GameScene {
    [RequireComponent(typeof(Text))]
    [ExecuteAlways]
    public class Scoreboard: MonoBehaviour {
        public string valueMask = "000000";
        int score = 0;
        Text valueText;

        void Awake() {
            InitializeDependencies();
        }

        void InitializeDependencies() {
            if(valueText == null)
                valueText = GetComponent<Text>();
        }

#if UNITY_EDITOR
        void Update() {
            InitializeDependencies();
            valueText.text = score.ToString(valueMask);
        }
#endif
    }
}