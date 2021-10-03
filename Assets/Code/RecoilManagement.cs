using UnityEngine;

public class RecoilManagement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidBody2D;
    [SerializeField] private Transform recoilDirection;

    public void AddRecoil(float recoilForce)
    {
        rigidBody2D.AddForceAtPosition((recoilDirection.position - transform.position).normalized * recoilForce,transform.position);        
    }
}
