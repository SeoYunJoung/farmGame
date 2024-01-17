using UnityEngine;
using UnityEngine.UI;

public class ToolSelector : MonoBehaviour
{
    public GameObject[] toolSlots = new GameObject[3]; 
    public Sprite[] toolImages = new Sprite[3]; 
    private int selectedToolIndex = 0;

    private void Start()
    {
        SelectTool(0); // 게임 시작 시 첫 번째 도구를 선택
    }

    private void Update()
    {
        // 도구 선택
        for (int i = 0; i < toolSlots.Length; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                SelectTool(i);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space)) // 스페이스 키를 눌렀을 때
        {
            UseTool(selectedToolIndex); // 현재 선택된 도구 사용
        }
    }

    // 도구를 선택하는 메소드
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

    // 도구를 사용하는 메소드
    private void UseTool(int index)
    {
        if (index < 0 || index >= toolSlots.Length)
            return;

        // 도구 사용 코드
    }
}
