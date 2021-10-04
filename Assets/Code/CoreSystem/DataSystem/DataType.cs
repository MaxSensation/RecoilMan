using UnityEngine;

namespace CoreSystem.DataSystem
{
    public abstract class DataType<T> : ScriptableObject
    {
        [SerializeField] private T defaultValue;
        protected internal T Data { get; set; }
        
        private void Awake()
        {
            if (Data != null) Data = defaultValue;
        }
    }
}