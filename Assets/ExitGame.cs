using UnityEngine;

public class ExitGame : MonoBehaviour
{
    private RecoilManInput _recoilManInput;

    private void Start()
    {
        _recoilManInput = new RecoilManInput();
        _recoilManInput.Player.Exit.Enable();
        _recoilManInput.Player.Exit.performed += _ => Application.Quit();
    }
}
