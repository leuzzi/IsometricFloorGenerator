using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.Tilemaps;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int[,] floorMapping;
    private Vector2Int[] corridorAnchor;
    public Vector2Int floorSize;
    public TileBase[] floor;

    // Coeff dans lequel je peux mettre une room
    private Vector2Int offSet;

    // Taille min et max d'une room
    public Vector2Int roomSize;
    public int roomPerCorridor;
    public int floorCorridor;
    public Tilemap tilemapref;
    public float UniqueRoomChance;
    private RoomClass[] rooms;
    private RoomClass roomInstance;

    // Start is called before the first frame update
    void Start()
    {
       InitiateGenerator();
    }

    void InitiateGenerator()
    {
        // Récupère le script RoomClass dans le fils
        roomInstance = GetComponentInChildren<RoomClass>();
        //Créer une nouvelle map
        floorMapping = new int[floorSize.x + 1, floorSize.y + 1];
        // Calcule l'offset en fonction de la taille du niveau
        CalculateOffSetXY(floorSize);
        // Calcule le nombre max de salle par couloir
        roomPerCorridor = CalculateMaxRoomPerCorridor();
        // Calcule la position de départ de chaque couloir
        corridorAnchor = CalculateCorridorAnchorByAxisY(floorSize);
        // Rempli la map de case vide
        FillFloorMappingWithEmpty();
        //DrawSquare(5,5);
        // Nouvelle liste de rooms
        rooms = new RoomClass[(roomPerCorridor * floorCorridor) + 1];
        // Lancement de l'algo de génération de salles
        rooms = GetRooms(rooms);
        // Ecriture des salles sur la map
        for (int index = 0; rooms[index] != null; index++)
        {
            PutRoomInMapping(rooms[index]);
        }
       DrawFloorWithVariation(new Vector3Int(0, 0, 0), new Vector3Int(floorSize.x, floorSize.y, 0), floor);
        }

    RoomClass[] GetRooms(RoomClass[] roomsList)
    {
        int totalRoom = 0;
        for (int curCorridor = 0; curCorridor < floorCorridor; curCorridor++)
        {
            for (Vector2Int curRoom = new Vector2Int(0, curCorridor); curRoom.x < (roomPerCorridor - 1); curRoom.x++)
            {
                if (curRoom.x == 4)
                {
                    ;
                } else
                {
                    rooms[totalRoom] = roomInstance.GenerateRoom(this.offSet, this.roomSize, curRoom, floorSize);
                    Debug.Log(rooms[totalRoom].name);
                    Debug.Log(rooms[totalRoom].position);
                    totalRoom++;
                }
                
            }
        }
        roomsList[totalRoom] = null;
        return roomsList;
    }

    void CalculateOffSetXY(Vector2Int size)
    {
        this.offSet.x = size.x / floorCorridor;
        this.offSet.y = size.y / floorCorridor;
    }

    Vector2Int[] CalculateCorridorAnchorByAxisY(Vector2Int size)
    {
        Vector2Int[] anchor = new Vector2Int[floorCorridor];

        for (int i = 0; i < floorCorridor; i++)
            anchor[i] = new Vector2Int(size.x, (this.offSet.y * i));
        return anchor;
    }
    Vector2Int[] CalculateCorridorAnchorByAxisX(Vector2Int size)
    {
        Vector2Int[] anchor = new Vector2Int[floorCorridor];

        for (int i = 0; i < floorCorridor; i++)
        {
            anchor[i] = new Vector2Int((offSet.x * i), size.y);
        }
        return anchor;
    }

    int CalculateMaxRoomPerCorridor()
    {
        int res = floorSize.x / roomSize.x;
        return res;
    }

    void FillFloorMappingWithEmpty()
    {
        for (int y = 0; y < floorSize.y; y++)
        {
            for (int x = 0; x < floorSize.x; x++)
            {
                floorMapping[x, y] = 0;
            }
        }
    }

    void PutRoomInMapping(RoomClass room)
    {
        int y = 0;
        int x = 0;
        int tmp;

        while (y < room.size.y)
        {
            while (x < room.size.x)
            {
                tmp = room.roomMapping[x, y];
                floorMapping[room.position.x + x, room.position.y + y] = tmp;
                x++;
            }
            x = 0;
            y++;
        } 
    }

    void DrawFloorWithVariation(Vector3Int position, Vector3Int size, TileBase[] tile)
    {
        for (int y = 0; y < floorSize.y; y++)
        {
            for (int x = 0; x < floorSize.x; x++)
            {
                tilemapref.SetTile(new Vector3Int(position.x + x, position.y + y, position.z), tile[floorMapping[position.x + x, position.y + y]]);
            }
        }
    }

    void DrawSquare(int x, int y)
    {
        Vector3Int pos = new Vector3Int(0, 0, 0);
        for (int i = 0; i < x; i++)
        {
            pos.x += 1;
            tilemapref.SetTile(pos, floor[1]);           
        }
        for (int i = 0; i < x; i++)
        {
            pos.y += 1;
            tilemapref.SetTile(pos, floor[1]);
        }
        for (int i = 0; i < x; i++)
        {
            pos.x -= 1;
            tilemapref.SetTile(pos, floor[1]);
        }
        for (int i = 0; i < x; i++)
        {
            pos.y -= 1;
            tilemapref.SetTile(pos, floor[1]);
        }
    } 

    // Update is called once per frame
    void Update()
    {
        
    
    }
}
