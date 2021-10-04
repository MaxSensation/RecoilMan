using UnityEngine;

public class DisableUserUI : MonoBehaviour
{
    [SerializeField] private GameObject userUI;

    private void Start()
    {
        userUI.SetActive(false);
    }
}
