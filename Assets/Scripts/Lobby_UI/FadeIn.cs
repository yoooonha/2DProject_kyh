using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    [SerializeField] Image _white;
    float time;//0����1���� deltaTime�� ���Ͽ� ���ӽð�
    float FadeTime = 10f;//���ʰ� ���ӵɰ���

    public void Start()
    {
        StartCoroutine(FadeFlow());
    }
    IEnumerator FadeFlow()
    {
        time = 0f;
        Color alpha = _white.color;//�ʱ�ȭ
        while (alpha.a < 0.5f)
        {
            time += Time.deltaTime / FadeTime;
            alpha.a = Mathf.Lerp(0, 1, time);
            _white.color = alpha;
        }

        yield return null;
    }
}
