using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolSelector : MonoBehaviour
{
    public GameObject[] toolSlots; // 도구 슬롯을 담는 배열
    public Sprite[] toolImages; // 도구 이미지를 담는 배열
    public int selectedToolIndex = 0; // 현재 선택된 도구의 인덱스

    private void Start()
    {
        SelectTool(selectedToolIndex); // 초기 도구 선택
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) // 1번 키를 눌렀을 때
        {
            SelectTool(0); // 1번 도구 선택
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SelectTool(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SelectTool(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SelectTool(3);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            SelectTool(4);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            SelectTool(5);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            SelectTool(6);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            SelectTool(7);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            SelectTool(8);
        }
    }

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
}
