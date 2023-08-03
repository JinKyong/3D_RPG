using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character.Ability.UI
{
    public class SkillWindow : MonoBehaviour
    {
        CanvasGroup group;

        private void Start()
        {
            group = GetComponent<CanvasGroup>();
        }

        public void SetAlpha(float a)
        {
            group.alpha = a;
        }
    }
}
