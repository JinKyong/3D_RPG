using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.State
{
    public interface IState
    {
        void OperateEnter(PlayerController p);
        void OperateUpdate(PlayerController p);
        void OperateExit(PlayerController p);
        IState InputHandle(PlayerController p);
    }
}
