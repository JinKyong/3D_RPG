using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character.Buff
{
    public class BuffSpeed : Buff
    {
        protected override void onBuff()
        {
            Player.Instance.Stat.runTimeSpeed += value;
        }
        protected override void offBuff()
        {
            Player.Instance.Stat.runTimeSpeed -= value;
        }
    }
}