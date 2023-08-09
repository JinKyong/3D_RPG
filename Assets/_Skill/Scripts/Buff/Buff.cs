using Character.Ability.Enum;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character.Buff
{
    public abstract class Buff : MonoBehaviour
    {
        protected float duration;
        protected float value;
        protected EValueType calType;

        protected Coroutine routine;

        public void Init(float duration, float value, EValueType calType)
        {
            this.duration = duration;
            this.value = value;
            this.calType = calType;

            if(routine != null)
            {
                StopCoroutine(routine);
                offBuff();
            }
            routine = StartCoroutine(onUseBuff());
        }

        IEnumerator onUseBuff()
        {
            onBuff();
            yield return new WaitForSeconds(duration);
            offBuff();
        }

        protected abstract void onBuff();
        protected abstract void offBuff();
    }
}
