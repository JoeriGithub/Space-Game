using System;
using UnityEngine;

[CreateAssetMenu(fileName = "RoomData", menuName = "RoomData", order = 1)]
public class RoomData : ScriptableObject
{
    [Serializable]
    private class TileInfo
    {
        public bool hasDoorNorth;
        public bool hasDoorEast;
        public bool hasDoorSouth;
        public bool hasDoorWest;
        public bool isRoomTile;
    }
    //create 9 tiles
    [SerializeField] private TileInfo[] tiles = new TileInfo[9];
    bool[,] tileShape = new bool[3, 3];

    private void OnEnable() {
        for (int i = 0; i < 9; i++)
        {
            tileShape[i % 3, i / 3] = tiles[i].isRoomTile;
        }
    }
    //functions to get tile info
    public bool[,] GetTileShape()
    {
        bool[,] tileInfo = new bool[3, 3];
        for (int i = 0; i < 9; i++)
        {
            tileInfo[i % 3, i / 3] = tiles[i].isRoomTile;
        }
        return tileInfo;
    }
}
