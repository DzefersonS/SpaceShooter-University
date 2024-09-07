using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
    [CreateAssetMenu(fileName = "PoolableObjectPoolSO", menuName = "Create New Poolable Object Pool SO")]
    public class PoolableObjectPoolSO : ScriptableObject
    {
        [SerializeField] private Poolable m_Prefab;
        [SerializeField] private int m_PreAllocatedSize;

        [SerializeField]
        private List<Poolable> m_Objects = default;
        private int m_Capacity = 0;

        public Transform container { private get; set; }
        public int activeObjectsCount { get; private set; }

        public Poolable GetFreeObject()
        {
            if (m_Objects == null || m_Objects.Capacity == 0 || activeObjectsCount == m_Capacity - 1)
            {
                ExpandPool();
            }

            Poolable obj = m_Objects[^1];
            m_Objects.Move(obj, activeObjectsCount++);
            obj.gameObject.SetActive(true);
            return obj;
        }

        private void ExpandPool()
        {
            if (container == null)
            {
                Debug.LogError("Container is null!");
                return;
            }

            m_Capacity += m_PreAllocatedSize;
            for (int i = 0; i < m_PreAllocatedSize; ++i)
            {
                m_Objects.Add(InstantiateObject());
            }
        }

        private Poolable InstantiateObject()
        {
            Poolable obj = Instantiate(m_Prefab, container);
            obj.gameObject.SetActive(false);
            obj.freeToPoolCallback = FreeObject;
            return obj;
        }

        private void FreeObject(Poolable poolable)
        {
            poolable.gameObject.SetActive(false);
            activeObjectsCount--;
        }

        public void DestroyContainer()
        {
            for (int i = m_Objects.Count - 1; i >= 0; --i)
            {
                Destroy(m_Objects[i]);
            }

            m_Objects = null;
        }
    }
}