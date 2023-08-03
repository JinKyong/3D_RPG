using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LoadingBG
{ 
    public class LoadingBG : MonoBehaviour
    {
        [SerializeField] private List<Image> images;
        [SerializeField] private float fadeInDuration = 1.0f;
        [SerializeField] private float fadeOutDuration = 1.0f;
        [SerializeField] private float displayDuration = 2.0f;

        private void Start()
        {
            // Deactivate all images at the beginning
            foreach (Image img in images)
            {
                img.gameObject.SetActive(false);
            }

            StartCoroutine(BackgroundFadeInAndOut());
        }

        private IEnumerator BackgroundFadeInAndOut()
        {
            while (true)
            {
                int randomIndex = Random.Range(0, images.Count);
                Image selectedImage = images[randomIndex];
                selectedImage.gameObject.SetActive(true); // Activate the selected image

                // Fade in effect
                float fadeInTime = 0.0f;
                while (fadeInTime < fadeInDuration)
                {
                    selectedImage.color = new Color(selectedImage.color.r,
                                                    selectedImage.color.g,
                                                    selectedImage.color.b,
                                                    fadeInTime / fadeInDuration);
                    fadeInTime += Time.deltaTime;
                    yield return null;
                }
                selectedImage.color = new Color(selectedImage.color.r,
                                                selectedImage.color.g,
                                                selectedImage.color.b,
                                                1);

                // Display the image for the given duration
                yield return new WaitForSeconds(displayDuration);

                // Fade out effect
                float fadeOutTime = 0.0f;
                while (fadeOutTime < fadeOutDuration)
                {
                    selectedImage.color = new Color(selectedImage.color.r,
                                                    selectedImage.color.g,
                                                    selectedImage.color.b,
                                                    1 - (fadeOutTime / fadeOutDuration));
                    fadeOutTime += Time.deltaTime;
                    yield return null;
                }
                selectedImage.color = new Color(selectedImage.color.r,
                                                selectedImage.color.g,
                                                selectedImage.color.b,
                                                0);

                selectedImage.gameObject.SetActive(false); // Deactivate the image after fading out

                // Wait for a short delay before starting the next fade in
                yield return null;
            }
        }
    }
}