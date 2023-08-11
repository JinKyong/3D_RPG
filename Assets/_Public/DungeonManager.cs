using Public;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonManager : MonoBehaviour
{
    [SerializeField] GameEvent clearEvent;

    public void Clear()
    {
        clearEvent.Raise();
    }
}
