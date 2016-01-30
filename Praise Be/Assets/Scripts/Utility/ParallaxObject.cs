using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Utility
{
    class ParallaxObject : MonoBehaviour
    {

        void OnBecameInvisible()
        {
        }

        void Update()
        {
            //if (this.transform.localPosition.x < -1.5f)
            //{
            //    Destroy(this.transform.parent.gameObject);
            //    Debug.Log("INVIS");
            //}
        }
    }
}
