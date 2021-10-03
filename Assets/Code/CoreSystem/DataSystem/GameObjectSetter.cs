using UnityEngine;

namespace CoreSystem.DataSystem
{
    public class GameObjectSetter : MonoBehaviour
    {
        [SerializeField] private GameObject data;
        [SerializeField] private GameObjectDataType gameObjectDataType;

        private void Start() => gameObjectDataType.Data = data;
    }
}