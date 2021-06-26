using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMgr : MonoBehaviour
{
    #region Singleton
    public static TileMgr Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this.gameObject);
        }
    }
    #endregion

    private GameObject player;
    public Tilemap fogTilemap, islandTilemap;
    public TileBase fogSmall, fogBig;
    public int playerFov;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");        
    }
    
    void Update()
    {
        UpdateFog();
    }

    void UpdateFog()
    {
        Vector3Int playerPos = fogTilemap.WorldToCell(player.transform.position);
        for (int dx = -10; dx <= 10; dx++)
        {
            for (int dy = -6; dy <= 6; dy++)
            {
                int SQRD = dx * dx + dy * dy;
                if (SQRD <= playerFov * playerFov)
                    fogTilemap.SetTile(playerPos + new Vector3Int(dx, dy, 0), null);
                else if (SQRD <= (playerFov + 1) * (playerFov + 1))
                    fogTilemap.SetTile(playerPos + new Vector3Int(dx, dy, 0), fogSmall);
                else
                    fogTilemap.SetTile(playerPos + new Vector3Int(dx, dy, 0), fogBig);
            }
        }
    }

    public bool HasTile(Tilemap _tileMap, Vector3 _pos)
    {
        Vector3Int cellPos = _tileMap.WorldToCell(_pos);
        return _tileMap.HasTile(cellPos);
    }
}
