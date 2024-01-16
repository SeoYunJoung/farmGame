using UnityEngine;
using UnityEngine.UI;

public class ToolSlot : MonoBehaviour
{
    public Sprite toolSprite; // �� ���Կ� ������ ���� ��������Ʈ

    private void Start()
    {
        var image = GetComponent<Image>();
        if (image != null)
            image.sprite = toolSprite; // ���Կ� ��������Ʈ ����
    }
}
