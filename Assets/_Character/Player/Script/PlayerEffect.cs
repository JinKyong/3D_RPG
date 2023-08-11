using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffect : MonoBehaviour
{
    [SerializeField] GameObject baseAtk;
    [SerializeField] GameObject meteoAtk;
    [SerializeField] GameObject backhandAtk;
    [SerializeField] GameObject jumpAtk;

    public void BaseAtkOn()
    {
        baseAtk.SetActive(true);
    }

    public void BaseAtkOff()
    {
        baseAtk.SetActive(false);
    }

    public void MeteoAtkOn()
    {
        meteoAtk.SetActive(true);
    }

    public void MeteoAtkOff()
    {
        meteoAtk.SetActive(false);
    }

    public void BackhandAtkOn()
    {
        backhandAtk.SetActive(true);
    }

    public void BackhandAtkOff()
    {
        backhandAtk.SetActive(false);
    }

    public void JumpAtkOn()
    {
        jumpAtk.SetActive(true);
    }

    public void JumpAtkOff()
    {
        jumpAtk.SetActive(false);
    }
}
