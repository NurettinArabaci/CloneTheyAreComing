using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    [System.Serializable]

    public class Pool
    {
        public string objectTag;
        public Transform parent;
        public int size;
        public GameObject prefab;
        
        
    }

    public static ObjectPooling Instance;

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDict;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        poolDict = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool item in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < item.size; i++)
            {
                GameObject obj = Instantiate(item.prefab,item.parent);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDict.Add(item.objectTag, objectPool);
        }
    }
    public GameObject GetSpawnObject(string tag, Vector3 pos, Quaternion rot)
    {
        if (poolDict[tag].Count <= 1)
        {
            GameObject objectSpawn = poolDict[tag].Dequeue();
            GameObject obj = Instantiate(objectSpawn);
            obj.SetActive(false);
            poolDict[tag].Enqueue(obj);
            objectSpawn.SetActive(true);
            objectSpawn.transform.position = pos;
            objectSpawn.transform.rotation = rot;

            return objectSpawn;
        }

        else
        {
            GameObject objectSpawn = poolDict[tag].Dequeue();
            objectSpawn.SetActive(true);
            objectSpawn.transform.position = pos;
            objectSpawn.transform.rotation = rot;

            return objectSpawn;
        }

    }
    public void BackToPool(GameObject objectToEnqueu, string tag)
    {
        objectToEnqueu.SetActive(false);
        poolDict[tag].Enqueue(objectToEnqueu);
    }

}
