using UnityEngine;
using UnityEngine.UI;

public class ToolSelector : MonoBehaviour
{
    public GameObject[] toolSlots = new GameObject[3]; 
    public Sprite[] toolImages = new Sprite[3]; 
    private int selectedToolIndex = 0;

    private void Start()
    {
        SelectTool(0); // ���� ���� �� ù ��° ������ ����
    }

    private void Update()
    {
        // ���� ����
        for (int i = 0; i < toolSlots.Length; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                SelectTool(i);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space)) // �����̽� Ű�� ������ ��
        {
            UseTool(selectedToolIndex); // ���� ���õ� ���� ���
        }
    }

    // ������ �����ϴ� �޼ҵ�
    private void SelectTool(int index)
    {
        if (index < 0 || index >= toolSlots.Length)
            return;

        foreach (var slot in toolSlots)
        {
            var outline = slot.GetComponent<Outline>();
            if (outline != null)
                outline.enabled = false;
        }

        var selectedOutline = toolSlots[index].GetComponent<Outline>();
        if (selectedOutline != null)
            selectedOutline.enabled = true;

        var toolImage = toolSlots[index].transform.Find("ToolImage").GetComponent<Image>();
        if (toolImage != null)
            toolImage.sprite = toolImages[index];

        selectedToolIndex = index;
    }

    // ������ ����ϴ� �޼ҵ�
    private void UseTool(int index)
    {
        if (index < 0 || index >= toolSlots.Length)
            return;

        // ���� ��� �ڵ�
    }
}
