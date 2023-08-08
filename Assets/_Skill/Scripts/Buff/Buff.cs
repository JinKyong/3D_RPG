using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character.Buff
{
    public abstract class Buff : MonoBehaviour
    {
        protected float duration;
        protected float value;

        public void Init(float duration, float value)
        {
            this.duration = duration;
            this.value = value;

            StartCoroutine(onUseBuff());
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
