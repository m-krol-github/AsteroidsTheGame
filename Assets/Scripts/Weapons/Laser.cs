using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class Laser : MonoBehaviour,IDestroyable
    {
        public void DestroyMe()
        {
            Destroy(this.gameObject);
        }

        public void InitLaser()
        {
            Destroy(this.gameObject, 1);
        }
    }
}