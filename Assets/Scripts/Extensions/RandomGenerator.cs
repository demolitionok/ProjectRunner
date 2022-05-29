using UnityEngine;

namespace Extensions
{
    public static class RandomGenerator
    {
        public static Vector2 GetRandomVector2(float leftBound, float rightBound)
        {
            var x = Random.Range(leftBound, rightBound);
            var y = Random.Range(leftBound, rightBound);

            return new Vector2(x, y);
        }
    }
}