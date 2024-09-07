using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
    public static class ExtensionMethods
    {
        public static void Move<T>(this List<T> list, T item, int newIndex)
        {
            if (item != null)
            {
                int oldIndex = list.IndexOf(item);
                if (oldIndex > -1)
                {
                    list.RemoveAt(oldIndex);

                    if (newIndex > oldIndex) newIndex--;

                    newIndex = Mathf.Clamp(newIndex, 0, list.Count);

                    list.Insert(newIndex, item);
                }
            }
        }

        public static Vector2 Clamp(this Vector2 vector, Vector2 min, Vector2 max) => vector = new Vector2()
        {
            x = Mathf.Clamp(vector.x, min.x, max.x),
            y = Mathf.Clamp(vector.y, min.y, max.y)
        };

        public static Vector3 Clamp(this Vector3 vector, Vector3 min, Vector3 max) => vector = new Vector3()
        {
            x = Mathf.Clamp(vector.x, min.x, max.x),
            y = Mathf.Clamp(vector.y, min.y, max.y),
            z = Mathf.Clamp(vector.z, min.z, max.z)
        };
    }
}
