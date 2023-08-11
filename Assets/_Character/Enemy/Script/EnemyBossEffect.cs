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
        Debug.Log("도끼공격");
        axeAtk.SetActive(true);
    }

    public void AxeAtkOff()
    {
        axeAtk.SetActive(false);
    }

    public void RoarAtkOn()
    {
        Debug.Log("불공격");
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
