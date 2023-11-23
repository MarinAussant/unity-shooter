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
            // G�n�rer une nouvelle position de mani�re al�atoire dans un certain rayon
            Vector3 newPos = originalPosition + Random.insideUnitSphere * amout;

            // Appliquer la nouvelle position � la cam�ra
            transform.position = newPos;

            // Attendre la prochaine frame
            yield return null;

            // Mettre � jour le temps �coul�
            elapsed += Time.deltaTime;
        }

        // R�tablir la position originale � la fin du shake
        transform.position = originalPosition;
    }
}
