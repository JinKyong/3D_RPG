using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stackable : MonoBehaviour
{
    public bool IsFull { get { return count == maxStack; } }
    public bool IsEmpty { get { return count == 0; } }
    public int Count { get { return count; } }

    [SerializeField] int maxStack;
    int count = 0;

    public void Plus()
    {
        count++;
    }
    public void Minus()
    {
        count--;
    }
}
