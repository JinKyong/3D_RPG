using UnityEngine;

namespace Zone
{
    public class Zone : MonoBehaviour
    {
        [SerializeField] GameObject Crash;

        [SerializeField] string targetTag;


        private void OnTriggerEnter(Collider other) // 트리거 버튼
        {
            if (other.CompareTag(targetTag))
            {
                Crash.SetActive(true);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag(targetTag))
            {
                Crash.SetActive(false);
            }
        }
    }
}