using UnityEngine;

public class AlwaysWithYouManager : MonoBehaviour
{
    private static AlwaysWithYouManager _instance;
    private void Start()
    {
        if (!_instance)
        {
            DontDestroyOnLoad(gameObject);
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
