using UnityEngine;

namespace _Code.Tiles.Factory
{
    public interface ITileFactory
    {
        GameObject CreateTileOfType(TileType type, Vector2 position);
    }
}