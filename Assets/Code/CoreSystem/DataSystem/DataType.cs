using UnityEngine;

namespace CoreSystem.DataSystem
{
    public abstract class DataType<T> : ScriptableObject
    {
        protected internal T Data { get; set; }
    }
}