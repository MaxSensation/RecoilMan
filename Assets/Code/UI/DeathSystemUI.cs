using System;
using TMPro;
using UnityEngine;

namespace UI
{
    public class DeathSystemUI : MonoBehaviour
    {
        public static Action ONDeathAddedEvent;
        [SerializeField] private TMP_Text scoreText;
        private int _currentDeaths;
        
        private void Start()
        {
            ONDeathAddedEvent += AddDeath;
        }

        private void AddDeath()
        {
            _currentDeaths += 1;
            UpdateUIText();
        }

        private void UpdateUIText()
        {
            scoreText.SetText(_currentDeaths.ToString());
        }
    }
}