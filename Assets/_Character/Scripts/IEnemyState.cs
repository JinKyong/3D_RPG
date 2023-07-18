using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Enemy.State
{
    public interface IEnemyState
    {
        void OperateEnter(EnemyController e);
        void OperateUpdate(EnemyController e);
        void OperateExit(EnemyController e);
        IEnemyState InputHandle(EnemyController e);
    }
}
