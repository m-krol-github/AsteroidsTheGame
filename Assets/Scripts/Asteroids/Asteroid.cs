using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class Asteroid : MonoBehaviour, IDestroyable
    {
        public void DestroyMe()
        {
            Destroy(this.gameObject);
        }
    }
}