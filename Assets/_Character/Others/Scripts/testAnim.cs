using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using System.Linq;

public class testAnim : MonoBehaviour
{
    Animator anim;
    bool toggle;

    [SerializeField] AnimationClip clip;
    AnimatorController controller;
    AnimatorState state;

    void Start()
    {
        anim = GetComponent<Animator>();
        toggle = false;

        controller = anim.runtimeAnimatorController as AnimatorController;
        state = controller.layers[0].stateMachine.states.FirstOrDefault(s => s.state.name.Equals("testAnim")).state;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            toggle = !toggle;
            anim.SetBool("test", toggle);
            controller.SetStateEffectiveMotion(state, clip);
        }
    }
}
