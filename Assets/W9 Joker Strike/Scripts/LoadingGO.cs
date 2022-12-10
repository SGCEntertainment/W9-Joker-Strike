using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class LoadingGO : MonoBehaviour
{
    public static Action OnLoadingStarted { get; set; } = delegate { };
    public static Action OnLoadingFinished { get; set; } = delegate { };

    private IEnumerator Start()
    {
        OnLoadingStarted?.Invoke();

        float et = 0.0f;
        float loadingTime = Random.Range(1.5f, 4.0f);

        while(et < loadingTime)
        {
            et += Time.deltaTime;
            yield return null;
        }

        gameObject.SetActive(false);
        OnLoadingFinished?.Invoke();
    }
}
