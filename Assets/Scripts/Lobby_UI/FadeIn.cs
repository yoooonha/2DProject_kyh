using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    public Image _white;
    float time;//0����1���� deltaTime�� ���Ͽ� ���ӽð�
    float FadeTime = 0.5f;//���ʰ� ���ӵɰ���

    public void Fade()
    {
        StartCoroutine(FadeFlow());
    }
    IEnumerator FadeFlow()
    {
        _white.gameObject.SetActive(true);
        time = 0f;
        Color alpha = _white.color;//�ʱ�ȭ
        while (alpha.a < 1f)
        {
            time += Time.deltaTime / FadeTime;
            alpha.a = Mathf.Lerp(0, 1, time);
            _white.color = alpha;
        yield return null;
        }
        yield return null;
    }
}
