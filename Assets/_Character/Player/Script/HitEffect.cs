using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffect : MonoBehaviour
{
    [SerializeField] GameObject hitEffect;

    public void EffectOn()
    {
        hitEffect.SetActive(true);
    }

    public void EffectOff()
    {
        hitEffect.SetActive(false);
    }
}
