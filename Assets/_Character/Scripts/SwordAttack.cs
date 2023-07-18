using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public Transform rightHand;

    MeshCollider colliderSword;
    private GameObject weaponSword;
    public int weaponDamage = 25;

    private void Start()
    {
        weaponSword = rightHand.GetChild(5).gameObject;
        colliderSword = weaponSword.GetComponent<MeshCollider>();

        colliderSword.enabled = false;
    }

    public void activateSword()
    {
        colliderSword.enabled = true;
    }

    public void inactiveSword()
    {
        colliderSword.enabled = false;
    }
}
