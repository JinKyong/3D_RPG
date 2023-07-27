using Character.Ability;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Public
{
    public abstract class DataTransferObject<T> : ScriptableObject
    {
        public T data;
    }
}
