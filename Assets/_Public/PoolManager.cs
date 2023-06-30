using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : Singleton<PoolManager>
{
    #region Pool.class
    class Pool
    {
        public GameObject Original { get; private set; }
        public Transform Root { get; set; }

        Stack<Poolable> poolStack = new Stack<Poolable>();
        public int Count { get { return poolStack.Count; } }
        public int defaultCount;

        public void Setup(GameObject original, int count)
        {
            Original = original;
            Root = new GameObject().transform;
            Root.name = $"{original.name}_Pool";

            defaultCount = count;

            for (int i = 0; i < defaultCount; i++)
            {
                Push(Create());
            }
        }

        public Poolable Create()
        {
            GameObject obj = Instantiate(Original);
            obj.name = Original.name;
            return obj.GetComponent<Poolable>();
        }

        public void Push(Poolable poolable)
        {
            if (poolable == null)
            {
                return;
            }

            poolable.transform.SetParent(Root);
            poolable.gameObject.SetActive(false);
            poolable.IsUsing = false;

            poolStack.Push(poolable);
        }
        public Poolable Pop(Transform parent)
        {
            Poolable poolable;

            if (poolStack.Count <= 0)
            {
                for (int i = 0; i < defaultCount; i++)
                {
                    Push(Create());
                }
            }
            poolable = poolStack.Pop();

            poolable.gameObject.SetActive(true);
            poolable.transform.SetParent(parent);
            poolable.IsUsing = true;

            // DontDestroyOnLoad 해제 용도
            //if (parent == null)
            //    poolable.transform.parent = Managers.Scene.CurrentScene.transform;

            return poolable;
        }
    }
    #endregion

    Dictionary<string, Pool> pool = new Dictionary<string, Pool>();
    Transform root;
    int defaultPoolCount = 10;

    public void Setup()
    {
        if(root == null)
        {
            root = new GameObject().transform;
            root.name = "Pool_Root";
            root.SetParent(transform);
        }
    }

    public void CreatePool(GameObject original)
    {
        Pool pool = new Pool();
        pool.Setup(original, defaultPoolCount);
        pool.Root.SetParent(root);

        this.pool.Add(original.name, pool);
    }
    public void CreatePool(GameObject original, int count)
    {
        Pool pool = new Pool();
        pool.Setup(original, count);
        pool.Root.SetParent(root);

        this.pool.Add(original.name, pool);
    }

    public void Push(GameObject original)
    {
        if (pool.ContainsKey(original.name) == false)
        {
            Destroy(original);
            return;
        }

        pool[original.name].Push(original.GetComponent<Poolable>());
    }

    public GameObject Pop(GameObject original)
    {
        if (pool.ContainsKey(original.name) == false)
        {
            Poolable pb = original.GetComponent<Poolable>();
            if (pb)
            {
                CreatePool(original);
            }
            else
            {
                return Instantiate(original);
            }
        }

        return pool[original.name].Pop(null).gameObject;
    }
    public GameObject Pop(GameObject original, Transform parent)
    {
        if(pool.ContainsKey(original.name) == false)
        {
            Poolable pb = original.GetComponent<Poolable>();
            if(pb)
            {
                CreatePool(original);
            }
            else
            {
                return Instantiate(original, parent);
            }
        }
        //pool[original.name]

        return pool[original.name].Pop(parent).gameObject;
    }

    public GameObject GetOriginal(string name)
    {
        if(pool.ContainsKey(name) == false)
        {
            return null;
        }

        return pool[name].Original;
    }

    public void Clear()
    {
        foreach (Transform child in root)
        {
            Destroy(child.gameObject);
        }

        pool.Clear();
    }
}
