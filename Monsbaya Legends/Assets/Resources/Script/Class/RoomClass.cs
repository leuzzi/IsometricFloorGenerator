using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomClass : MonoBehaviour
{
    public string id;
    public int[,] roomMapping;
    public Vector2Int roomSize;
    public TileScript[] tiles;
    public Vector2Int position;
    public Vector2Int size;
    public RoomClass room;
    GridManager test;
    // Start is called before the first frame update
    void Start()
    {
    }

    public RoomClass GenerateRoom(Vector2Int range,
        Vector2Int roomSize, Vector2Int curRoom, Vector2Int floorSize)
    {
        this.roomSize = roomSize;
        test = GetComponentInParent<GridManager>();
        this.room = gameObject.AddComponent<RoomClass>();
        room.id = "room nb " + curRoom;
            range.x *= curRoom.x;
            range.y *= curRoom.y;
        CalculateStartPointPosition(range, roomSize);
        CalculateRoomSize(range, curRoom, floorSize);
        room.roomMapping = new int[room.size.x + 1, room.size.y + 1];
        FillRoomWithGround();
        PutRoomWall();
        return room;
    }

    void CalculateStartPointPosition(Vector2Int range,  Vector2Int roomSize)
    {
        int x = Random.Range(range.x, (range.x + (roomSize.x - roomSize.y)));
        int y = Random.Range(range.y, (range.y + (roomSize.x - roomSize.y)));
        room.position = new Vector2Int(x, y);
    }

    void CalculateRoomSize(Vector2Int range, Vector2Int curRoom, Vector2Int floorSize)
    {
        room.size.x = Random.Range(roomSize.y, roomSize.x);
        room.size.y = Random.Range(roomSize.y, roomSize.x);
        if (room.size.x + room.position.x > floorSize.x)
            room.size.x /= 2;
        if (room.size.y + room.position.y > floorSize.y)
            room.size.y /= 2;
    }

    void PutRoomWall()
    {
        for (int x = 0; x <= (room.size.x); x++)
        {
            //test.tilemapref.SetTile(pos, test.floor[1]);
            room.roomMapping[x, 0] = 1;
        }
        for (int y = 0; y <= (room.size.y); y++)
        {
            //test.tilemapref.SetTile(pos, test.floor[1]);
            room.roomMapping[0, y] = 1;
        }
        for (int x = 0; x <= (room.size.x); x++)
        {
            //test.tilemapref.SetTile(pos, test.floor[1]);
            room.roomMapping[x, (room.size.y - 1)] = 1;
        }
        
        for (int y = 0; y <= (room.size.y); y++)
        {
            //test.tilemapref.SetTile(pos, test.floor[1]);
            room.roomMapping[(room.size.x - 1), y] = 1;
        }
    }

    void FillRoomWithGround()
    {
        for (int y = 0; y < room.size.y; y++)
        {
            for (int x = 0; x < room.size.x; x++)
            {
                room.roomMapping[x, y] = 2;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
