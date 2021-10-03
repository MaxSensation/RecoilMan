using UnityEngine;

namespace CoreSystem
{
    public static class HelpClass
    {
        public static Quaternion GetRotationTowardsPosition(Vector3 startPosition, Vector3 endPosition)
        {
            var direction = endPosition - startPosition;
            return Quaternion.AngleAxis(Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f, Vector3.forward);
        }
    }
}