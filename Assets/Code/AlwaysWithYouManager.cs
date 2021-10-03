using UnityEngine;

public class AlwaysWithYouManager : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
