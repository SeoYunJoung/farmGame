using UnityEngine;
using UnityEngine.UI;

public class ToolSlot : MonoBehaviour
{
    public Image toolImage; // 이 슬롯에 설정할 도구 이미지

    public void SetImage(Sprite sprite)
    {
        toolImage.sprite = sprite; // 슬롯에 스프라이트 설정
    }
}
