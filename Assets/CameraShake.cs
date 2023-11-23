using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{

    private Vector3 originalPosition;

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
    }


    public void Shake(float shakeDuration, float shakeAmout)
    {
        StartCoroutine(ShakeCoroutine(shakeDuration, shakeAmout));
    }

    IEnumerator ShakeCoroutine(float shakeDuration, float shakeAmout)
    {
        float elapsed = 0.0f;
        float amout = shakeAmout;

        while (elapsed < shakeDuration)
        {
            // Générer une nouvelle position de manière aléatoire dans un certain rayon
            Vector3 newPos = originalPosition + Random.insideUnitSphere * amout;

            // Appliquer la nouvelle position à la caméra
            transform.position = newPos;

            // Attendre la prochaine frame
            yield return null;

            // Mettre à jour le temps écoulé
            elapsed += Time.deltaTime;
        }

        // Rétablir la position originale à la fin du shake
        transform.position = originalPosition;
    }
}
