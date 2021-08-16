using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
    public class PoolingSystem : MonoBehaviour
    {
        public GameObject UseObject(GameObject obj,Vector3 pos,Quaternion rot)
        {
            return Instantiate(obj, pos, rot);
        }

        public void ReturnObject(GameObject obj)
        {
            Destroy(obj);
        }
    }
}