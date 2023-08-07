using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public abstract class State<T>
    {
/*        AnimationClip clip;
        public abstract void Init(T t);*/

        public abstract void OperateEnter(T t);
        public abstract void OperateUpdate(T t);
        public abstract void OperateExit(T t);
        public abstract State<T> InputHandle(T t);
    }
}
