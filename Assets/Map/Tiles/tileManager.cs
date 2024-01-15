using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class tileManager : MonoBehaviour
{
    [SerializeField] private Tilemap interactableMap; //���� ���� ���� Ÿ�ϸ�
    [SerializeField] private Tile hiddenInteractableTile; //���� Ÿ�� �̹���
    [SerializeField] private Tile fieldTile; //���� Ÿ�� �̹���
    void Start()
    {
        foreach(var position in interactableMap.cellBounds.allPositionsWithin)
        {
            //���� ���� �� ��� ���� ���� ������ ��������
            TileBase tile = interactableMap.GetTile(position);
            if (tile != null && tile.name == "Interactable_V") {
                interactableMap.SetTile(position, hiddenInteractableTile);
            }
            
        }

    }

    //���� ���� ���� ã��
    public bool IsInteractable(Vector3Int position)
    {
        TileBase tile = interactableMap.GetTile(position);
        
        if(tile != null)
        {
            if(tile.name == "Interactable")
            {
                return true;
            }
        }

        return false;
    }


    //���� Ÿ�� set
    public void SetField(Vector3Int position)
    {
        interactableMap.SetTile(position, fieldTile);
    }

    void Update()
    {
        
    }
}
