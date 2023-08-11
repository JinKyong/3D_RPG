using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using LoadingSlider;
using UnityEngine.UI;


namespace Zone
{
    public class Potal : Zone
    {
        public void MoveMap()
        {
            GameSceneManager.Instance.LoadSceneAsync(1);
        }
    }
}