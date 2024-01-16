using UnityEngine;
using UnityEngine.UI;

public class ToolSlot : MonoBehaviour
{
    public Sprite toolSprite; // 이 슬롯에 설정할 도구 스프라이트

    private void Start()
    {
        var image = GetComponent<Image>();
        if (image != null)
            image.sprite = toolSprite; // 슬롯에 스프라이트 설정
    }
}
