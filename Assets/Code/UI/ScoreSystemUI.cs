using System;
using TMPro;
using UnityEngine;

namespace UI
{
    public class ScoreSystemUI : MonoBehaviour
    {
        public static Action<int> ONScoreAddedEvent;
        [SerializeField] private TMP_Text scoreText;
        private int _currentScore;
        
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
    }
}