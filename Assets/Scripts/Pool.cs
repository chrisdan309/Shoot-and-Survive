using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    public ObjectPool objectPool;
    public List<ObjectPool> readyObjects;
    public List<ObjectPool> inUseObjects;

    public ObjectPool Instantiate(Vector3 position, Quaternion rotation){
        ObjectPool obj = null;
        if(readyObjects.Count > 0)
        {
            obj = readyObjects[0];
            obj.objectState = ObjectState.InUse;
            obj.transform.position = position;
            obj.transform.rotation = rotation;
            readyObjects.Remove(obj);
            inUseObjects.Add(obj);

            obj.gameObject.SetActive(true);
            return obj;
        }
        else
        {
            obj = Object.Instantiate(objectPool, position, rotation);
            obj.objectState = ObjectState.InUse;
            inUseObjects.Add(obj);
            return obj;
        }
    }

    public void Destroy(ObjectPool objectPool)
    {
        if(objectPool.objectState == ObjectState.InUse)
        {
            objectPool.transform.position = Vector3.zero;
            objectPool.transform.rotation = Quaternion.identity;
            objectPool.gameObject.SetActive(false);
            inUseObjects.Remove(objectPool);
            readyObjects.Add(objectPool);
            objectPool.objectState = ObjectState.Ready;

            if(objectPool.gameObject.TryGetComponent<Rigidbody2D>(out Rigidbody2D rbd))
            {
                rbd.velocity = Vector2.zero;
            }

        }        
    }

}
