using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class tileManager : MonoBehaviour
{
    [SerializeField] private Tilemap interactableMap; //경작 가능 영역 타일맵
    [SerializeField] private Tile hiddenInteractableTile; //투명 타일 이미지
    [SerializeField] private Tile fieldTile; //경작 타일 이미지
    [SerializeField] private Tile fieldTile_W; //젖은 경작 타일 이미지
    [SerializeField] private Tile SeedTile; //씨앗 타일 이미지
    [SerializeField] private Tile SeedTile_W; //젖은 씨앗 타일 이미지
    void Start()
    {
        foreach(var position in interactableMap.cellBounds.allPositionsWithin)
        {
            //게임 실행 시 모든 경작 가능 영역을 투명으로
            TileBase tile = interactableMap.GetTile(position);
            if (tile != null && tile.name == "Interactable_V") {
                interactableMap.SetTile(position, hiddenInteractableTile);
            }
            
        }

    }

    //경작 가능 영역 찾기
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

    //씨앗 심기 가능 영역 찾기
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

    //물주기 가능 영역 찾기
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



    //경작 타일 set
    public void SetField(Vector3Int position)
    {
        interactableMap.SetTile(position, fieldTile);
    }

    //씨앗 타일 set
    public void SetSeed(Vector3Int position)
    {
        interactableMap.SetTile(position, SeedTile);
    }

    //물주기 set
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
