using UnityEngine;

public class MenuButton : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject optionsMenu;
    [SerializeField] private GameObject CreditsMenu;
    private RecoilManInput _recoilManInput;
    private bool _isMenuOpen;
    private bool _gameHasStarted;
    
    private void Start()
    {
        _recoilManInput = new RecoilManInput();
        _recoilManInput.Player.Menu.Enable();
        _recoilManInput.Player.Menu.started += _ => PressedButton();
    }

    private void PressedButton()
    {
        if (!_gameHasStarted) return;
        
        if (_isMenuOpen)
            DisableMenu();
        else
            EnableMenu();
    }

    public void EnableMenu()
    {
        if (mainMenu) mainMenu.SetActive(true);
        if (optionsMenu) optionsMenu.SetActive(false);
        if (CreditsMenu) CreditsMenu.SetActive(false);
        Time.timeScale = 0f;
        _isMenuOpen = true;
    }
    
    public void DisableMenu()
    {
        if (mainMenu) mainMenu.SetActive(false);
        if (optionsMenu) optionsMenu.SetActive(false);
        if (CreditsMenu) CreditsMenu.SetActive(false);
        Time.timeScale = 1f;
        _isMenuOpen = false;
        _gameHasStarted = true;
    }
}
