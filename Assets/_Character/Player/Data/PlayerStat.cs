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
        [Header("InitValue")]
        [SerializeField] float initHealth;
        [SerializeField] float initMana;
        [SerializeField] float initAttack;
        [SerializeField] float initSpeed;
        [SerializeField] float initJumpPower;


        //Runtime Value
        [Space]
        [Header("RuntimeValue")]
        public float runTimeMaxHealth;
        public float runTimeHealth;
        public float runTimeMaxMana;
        public float runTimeMana;

        public float runTimeAttack;
        public float runTimeSpeed;
        public float runTimeJumpPower;

        public void OnBeforeSerialize()
        {

        }

        public void OnAfterDeserialize()
        {
            runTimeMaxHealth = initHealth;
            runTimeHealth = runTimeMaxHealth;
            runTimeMaxMana = initMana;
            runTimeMana = runTimeMaxMana;

            runTimeAttack = initAttack;
            runTimeSpeed = initSpeed;
            runTimeJumpPower = initJumpPower;
        }
    }
}
