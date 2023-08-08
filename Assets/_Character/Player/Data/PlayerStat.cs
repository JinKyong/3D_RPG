using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    [CreateAssetMenu(fileName ="PlayerStat",
        menuName ="ScriptableObjects/Player/Stat")]
    public class PlayerStat : ScriptableObject, ISerializationCallbackReceiver
    {
        //Initial Value
        [SerializeField] float initHealth;

        //Runtime Value
        public float runTimeHealth;

        public void OnBeforeSerialize()
        {

        }

        public void OnAfterDeserialize()
        {
            //runTimeHealth = initHealth;
        }
    }
}
