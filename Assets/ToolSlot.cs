using UnityEngine;
using UnityEngine.UI;

public class ToolSlot : MonoBehaviour
{
    public Image toolImage; // �� ���Կ� ������ ���� �̹���

    public void SetImage(Sprite sprite)
    {
        toolImage.sprite = sprite; // ���Կ� ��������Ʈ ����
    }
}
