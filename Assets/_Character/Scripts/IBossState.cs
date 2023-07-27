using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy.State
{
    public interface IBossState
    {
        void OperateEnter(BossController b);
        void OperateUpdate(BossController b);
        void OperateExit(BossController b);
        IBossState InputHandle(BossController b);
    }
}
