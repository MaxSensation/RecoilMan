using UnityEngine;

public class PushBackWhenShoot : MonoBehaviour
{
    private Rigidbody2D _body;

    private void Start()
    {
        _body = GetComponent<Rigidbody2D>();
    }

    public void AddPushBack(Vector2 force, Vector2 position)
    {
        _body.AddForceAtPosition(force, position);
    }
}
