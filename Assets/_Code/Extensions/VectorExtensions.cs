using UnityEngine;

namespace _Code.Extensions
{
    public static class VectorExtensions
    {
        public static Vector2 OneXAxis(this Vector2 vector) =>
            new Vector2(1, 0);
        
        public static Vector2 OneYAxis(this Vector2 vector) =>
            new Vector2(0, 1);
    }
}