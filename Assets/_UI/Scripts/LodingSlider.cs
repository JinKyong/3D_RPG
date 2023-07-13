using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LodingSlider : MonoBehaviour
{
    [SerializeField] Slider progressBar;
    [SerializeField] Image Image;    // ����ȭ��
    

    private float loadingProgress = 0f;
    private float fillSpeed = 0.4f;
    private bool isPaused = false;

    private void Start()
    {
        StartCoroutine(RandomPauseCoroutine());
        StartCoroutine(StartLoadingCoroutine());
    }

    private IEnumerator StartLoadingCoroutine()
    {
        yield return new WaitForSeconds(2f); // 2�� ���

        while (loadingProgress < 1f)
        {
            if (!isPaused)
            {
                loadingProgress += fillSpeed * Time.deltaTime;
            }

            progressBar.value = loadingProgress;

            yield return null;
        }

        if (loadingProgress >= 1f)
        {
            yield return new WaitForSeconds(0.5f); // 0.5�� ���

            // ���� ������ ��ȯ
            SceneManager.LoadScene("Lobby");
        }
    }

    private IEnumerator RandomPauseCoroutine()
    {
        while (true)
        {
            float randomPauseTime = Random.Range(1f, 3f); // 1�ʺ��� 3�� ������ ������ �ð����� ����
            yield return new WaitForSeconds(randomPauseTime);

            isPaused = true;

            float randomResumeTime = Random.Range(1f, 3f); // 1�ʺ��� 3�� ������ ������ �ð����� ���� ����
            yield return new WaitForSeconds(randomResumeTime);

            isPaused = false;
        }
    }
}
