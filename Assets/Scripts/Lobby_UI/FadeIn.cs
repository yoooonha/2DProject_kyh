using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    [SerializeField] Image _white;
    float time;//0부터1까지 deltaTime을 더하여 지속시간
    float FadeTime = 10f;//몇초간 지속될건지

    public void Start()
    {
        StartCoroutine(FadeFlow());
    }
    IEnumerator FadeFlow()
    {
        time = 0f;
        Color alpha = _white.color;//초기화
        while (alpha.a < 0.5f)
        {
            time += Time.deltaTime / FadeTime;
            alpha.a = Mathf.Lerp(0, 1, time);
            _white.color = alpha;
        }

        yield return null;
    }
}
