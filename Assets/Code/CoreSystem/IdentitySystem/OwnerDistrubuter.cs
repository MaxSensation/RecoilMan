using UnityEngine;

namespace CoreSystem.IdentitySystem
{
    public class OwnerDistrubuter : MonoBehaviour
    {
        [SerializeField] private Owner owner;
        private void Awake()
        {
            foreach (var property in GetComponents<IProperty>()) property.SetOwner(owner);
        }
    }
}