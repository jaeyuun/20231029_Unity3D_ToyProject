using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextTwinkle : MonoBehaviour
{
    public float blinkInterval = 0.5f; // 반짝이는 간격
    private Text textComponent;
    private bool isBlinking = false;

    private void Start()
    {
        textComponent = GetComponent<Text>();
        if (textComponent == null)
        {
            Debug.LogError("TextTwinkle 스크립트를 Text 컴포넌트에 적용해야 합니다.");
            enabled = false;
        }

        // 반짝이는 코루틴 시작
        StartCoroutine(BlinkText());
    }

    private IEnumerator BlinkText()
    {
        while (true)
        {
            isBlinking = !isBlinking;
            textComponent.enabled = isBlinking;
            yield return new WaitForSeconds(blinkInterval);
        }
    }
}