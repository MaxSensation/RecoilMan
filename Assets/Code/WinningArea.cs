using TMPro;
using UI;
using UnityEngine;

public class WinningArea : MonoBehaviour
{
    [SerializeField] private GameObject winningScreen;
    [SerializeField] private TMP_Text totalDeathText;
    [SerializeField] private TMP_Text totalCoinsText;
    
    private bool _hasBeenTriggerd;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_hasBeenTriggerd || !other.CompareTag("Player")) return;
        winningScreen.SetActive(true);
        totalDeathText.SetText(DeathSystemUI.GetTotalDeaths().ToString());
        DeathSystemUI.ResetDeaths();
        totalCoinsText.SetText(ScoreSystemUI.GetTotalCoins().ToString());
        ScoreSystemUI.ResetCoins();
        _hasBeenTriggerd = true;
    }
}
