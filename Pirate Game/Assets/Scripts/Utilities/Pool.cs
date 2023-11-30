using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PoolType
{
    CannonBall,
    TripleCannonBall,
    EnemyChaser,
    EnemyShooter
}

public class Pool : MonoBehaviour
{
    [SerializeField]
    private PoolComponent [] _pools;

    private Dictionary<PoolType, PoolComponent> poolDictionary;

    private PoolComponent usedPool;

    private IEnable poolItem;

    public void InitPool()
    {
        poolDictionary = new Dictionary<PoolType, PoolComponent>();

        foreach (PoolComponent poll in _pools)
        {
            poolDictionary.Add(poll.type, poll);

            CreatePool(poll);
        }
    }

    public void Reset()
    {
        for(int i = 0; i < _pools.Length; i++)
        {
            DisableObjects(_pools[i].poolList);         
        }
    }

    private void DisableObjects(List<IEnable> poolObjects)
    {
        foreach (IEnable poolObject in poolObjects)
        {
            poolObject.Reset();
        }
    }


    private void CreatePool(PoolComponent pool)
    {
        pool.poolList = new List<IEnable>();

        for (int i = 0; i < pool.size; i++)
        {
            poolItem = CreatePoolItem(pool);

            if(poolItem != null)
                pool.poolList.Add(poolItem);   
        }
    }

    private IEnable CreatePoolItem(PoolComponent pool)
    {
        GameObject prefab = Instantiate(pool.prefab, pool.parent);

        poolItem = prefab.GetComponent<IEnable>();

        if (poolItem == null)
            return null;

        poolItem.DisableComponent();
        return poolItem;
    }

    public IEnable GetItem(PoolType type)
    {
        usedPool = null;

        usedPool = poolDictionary[type];

        foreach(IEnable poolItem in usedPool.poolList)
        {
            if (!poolItem.IsActive)
                return poolItem;
        }

        IEnable item = CreatePoolItem(usedPool);

        if (item == null)
            return null;

        usedPool.poolList.Add(item);

        return poolItem;

    }
}

[System.Serializable]
public class PoolComponent
{

    public GameObject prefab;

    public int size;

    public PoolType type;

    public Transform parent;

    public List<IEnable> poolList;

}
