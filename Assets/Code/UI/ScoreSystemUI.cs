using System;
using TMPro;
using UnityEngine;

namespace UI
{
    public class ScoreSystemUI : MonoBehaviour
    {
        public static Action<int> ONScoreAddedEvent;
        [SerializeField] private TMP_Text scoreText;
        private static int _currentScore;
        
        private void Start()
        {
            ONScoreAddedEvent += AddScore;
        }

        private void AddScore(int amount)
        {
            _currentScore += amount;
            UpdateUIText();
        }

        private void UpdateUIText()
        {
            scoreText.SetText(_currentScore.ToString());
        }
        
        public static int GetTotalCoins()
        {
            return _currentScore;
        }

        public static void ResetCoins()
        {
            _currentScore = 0;
        }
    }
}