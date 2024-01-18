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
    [SerializeField] private Tile fieldTile_W; //���� ���� Ÿ�� �̹���
    [SerializeField] private Tile SeedTile; //���� Ÿ�� �̹���
    [SerializeField] private Tile SeedTile_W; //���� ���� Ÿ�� �̹���
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

    //���� �ɱ� ���� ���� ã��
    public bool IsSeed(Vector3Int position)
    {
        TileBase tile = interactableMap.GetTile(position);

        if (tile != null)
        {
            if (tile.name == "tiles_441")
            {
                return true;
            }
        }

        return false;
    }

    //���ֱ� ���� ���� ã��
    public bool IsWater_F(Vector3Int position)
    {
        TileBase tile = interactableMap.GetTile(position);

        if (tile != null)
        {
            if (tile.name == "tiles_441")
            {
                return true;
            }
        }

        return false;
    }
    public bool IsWater_S(Vector3Int position)
    {
        TileBase tile = interactableMap.GetTile(position);

        if (tile != null)
        {
            if (tile.name == "Seed")
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

    //���� Ÿ�� set
    public void SetSeed(Vector3Int position)
    {
        interactableMap.SetTile(position, SeedTile);
    }

    //���ֱ� set
    public void SetWater_F(Vector3Int position)
    {
        interactableMap.SetTile(position, fieldTile_W);
    }
    public void SetWater_S(Vector3Int position)
    {
        interactableMap.SetTile(position, SeedTile_W);
    }

    void Update()
    {
        
    }
}
