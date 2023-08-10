using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class ScreenFlash : Singleton<ScreenFlash>
{
    public Volume postProcessingVolume;
    private Vignette vignette;

    public Color flashColor = Color.red;
    public float flashDuration = 0.2f;
    public AnimationCurve flashCurve = AnimationCurve.EaseInOut(0, 1, 1, 0);

    private void Start()
    {
        if (postProcessingVolume.profile.TryGet(out vignette))
        {
            vignette.intensity.value = 0;
        }
    }

    public void FlashScreen()
    {
        StartCoroutine(FlashCoroutine());
        TheAudioManager.Instance.PlaySFX("Hurt");
    }

    private IEnumerator FlashCoroutine()
    {
        float startTime = Time.time;

        while (Time.time < startTime + flashDuration)
        {
            float elapsedTime = Time.time - startTime;
            float flashAlpha = flashCurve.Evaluate(elapsedTime / flashDuration);

            if (vignette != null)
            {
                vignette.color.Override(flashColor);
                vignette.intensity.Override(flashAlpha);
            }

            yield return null;
        }

        if (vignette != null)
        {
            vignette.intensity.Override(0);
        }
    }
}