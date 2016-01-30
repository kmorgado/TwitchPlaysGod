using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Utility
{
    class ParallaxObjectList : MonoBehaviour
    {

        List<GameObject> ParallaxObjects;

        GameObject objectHome = null;
        int maxAmount = 5;
        string objectFilePath;


        public void CheckForOffscreenObjects()
        {
            List<GameObject> safeToDelete = new List<GameObject>();
            foreach (GameObject parallax in ParallaxObjects.ToList())
            {

                if (parallax.transform.localPosition.x < -1.4f)
                {
                    AppendNewObject(1);
                    safeToDelete.Add(parallax);
                }
            }


            foreach (GameObject parallax in safeToDelete)
            {
                lock (ParallaxObjects)
                {
                    ParallaxObjects.Remove(parallax);
                    Destroy(parallax);
                }
            }

        }


        public void CreateObjects(int amount, string objectLocation, GameObject Object_Home)
        {
            //If nothing is setup... set it up
            if (objectHome == null)
                objectHome = Object_Home;

            objectFilePath = objectLocation;
            
             //Store the last sprite to use it as a reference;
            tk2dSprite lastSprite = null;

            ParallaxObjects = new List<GameObject>();

            for (int i = 0; i < amount; i++)
            {
                GameObject tempObject = (GameObject)Instantiate(Resources.Load(objectFilePath));

                tempObject.transform.parent = objectHome.transform;

                if (lastSprite != null)
                {
                    tempObject.transform.localPosition = new Vector3(lastSprite.transform.localPosition.x + ((lastSprite.GetBounds().center.x + lastSprite.GetBounds().extents.x) * 2) - .01f, lastSprite.transform.localPosition.y, lastSprite.transform.localPosition.z);
                }

                //If object is null this is the first time around the loop do nothing besides set the last object
                lastSprite = tempObject.GetComponent<tk2dSprite>();

                ParallaxObjects.Add(tempObject);
            }

        }

        public void AppendNewObject(int amount)
        {
            tk2dSprite lastSprite = null;

            if (ParallaxObjects.Count > 0)
                lastSprite = ParallaxObjects.Last().GetComponent<tk2dSprite>();

                CreateSingleNewObject(lastSprite);

        }


        public void CreateSingleNewObject(tk2dSprite lastSprite)
        {
            GameObject tempObject = (GameObject)Instantiate(Resources.Load(objectFilePath));

            tempObject.transform.parent = objectHome.transform;

            if (lastSprite != null)
            {
                tempObject.transform.localPosition = new Vector3(lastSprite.transform.localPosition.x + ((lastSprite.GetBounds().center.x + lastSprite.GetBounds().extents.x) * 2) - .01f, lastSprite.transform.localPosition.y, lastSprite.transform.localPosition.z);
            }

            //If object is null this is the first time around the loop do nothing besides set the last object
            lastSprite = tempObject.GetComponent<tk2dSprite>();

            lock(ParallaxObjects)
                ParallaxObjects.Add(tempObject);
        }


        public void ApplyMotion(float amount)
        {
            foreach (GameObject parallax in ParallaxObjects)
            {
                parallax.transform.Translate(new Vector3(amount * Time.deltaTime, 0, 0));
            }
        }

    }
}
