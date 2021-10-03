using UnityEngine;

namespace CoreSystem.IdentitySystem
{
    public class Owner : MonoBehaviour
    {
        private void Awake()
        {
            foreach (var property in GetComponents<IProperty>()) property.SetOwner(this);
        }
    }
}