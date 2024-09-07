using System;
using UnityEngine;

namespace Utils
{
    public abstract class Poolable : MonoBehaviour
    {
        private Action<Poolable> m_FreeToPoolCallback = default;

        public Action<Poolable> freeToPoolCallback { set => m_FreeToPoolCallback = value; }

        public virtual void Initialize()
        {

        }

        public virtual void FreeToPool()
        {
            m_FreeToPoolCallback.Invoke(this);
            gameObject.SetActive(false);
        }
    }
}