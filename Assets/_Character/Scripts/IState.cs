using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace State
{
    public interface IState<T>
    {
        void OperateEnter(T t);
        void OperateUpdate(T t);
        void OperateExit(T t);
        IState<T> InputHandle(T t);
    }

/*    public abstract class State<T>
    {
        public abstract State<T> InputHandle(T t);
        public virtual void OperateEnter(T t) { }
        public virtual void OperateUpdate(T t) { }
        public virtual void OperateExit(T t) { }
    }*/
}
