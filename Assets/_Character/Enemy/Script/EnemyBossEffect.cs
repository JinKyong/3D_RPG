using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBossEffect : MonoBehaviour
{
    [SerializeField] GameObject axeAtk;
    [SerializeField] GameObject roarAtk;
    [SerializeField] GameObject tornadoAtk;

    public void AxeAtkOn()
    {
        axeAtk.SetActive(true);
    }

    public void AxeAtkOff()
    {
        axeAtk.SetActive(false);
    }

    public void RoarAtkOn()
    {
        roarAtk.SetActive(true);
    }

    public void RoarAtkOff()
    {
        roarAtk.SetActive(false);
    }

    public void TornadoAtkOn()
    {
        tornadoAtk.SetActive(true);
    }

    public void TornadoAtkOff()
    {
        tornadoAtk.SetActive(false);
    }
}
