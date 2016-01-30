using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Utility
{
    class ParallaxHandler : Singleton<ParallaxHandler> 
    {
        //All backgrounds consists of the following objects
        public GameObject SkyObject;
        public GameObject Mountain_Home;
        public GameObject Hill_Home;

        public GameObject Ground_Home;
        public GameObject Road_Home;
        public GameObject Grass_Home;

        public GameObject Object_Home;

        ParallaxObjectList RoadList;
        ParallaxObjectList MountainList;
        ParallaxObjectList HillList;
        ParallaxObjectList GroundList;
        ParallaxObjectList GrassList;



        // Use this for initialization
        void Start()
        {
            Mountain_Home = GameObject.Find("Mountains");
            Hill_Home = GameObject.Find("Hills");

            Grass_Home = GameObject.Find("Grass");
            Ground_Home = GameObject.Find("Ground");
            Road_Home = GameObject.Find("Road");


            Object_Home = GameObject.Find("ParallaxSubItems");


            MountainList = new ParallaxObjectList();
            MountainList.CreateObjects(2, "Act1/MountainObject", Mountain_Home);

            HillList = new ParallaxObjectList();
            HillList.CreateObjects(3, "Act1/HillObject", Hill_Home);

            GrassList = new ParallaxObjectList();
            GrassList.CreateObjects(3, "Act1/GrassObject", Grass_Home);

            GroundList = new ParallaxObjectList();
            GroundList.CreateObjects(3, "Act1/GroundObject", Ground_Home);

            RoadList = new ParallaxObjectList();
            RoadList.CreateObjects(3, "Act1/RoadObject", Road_Home);


        }

        // Update is called once per frame
        void Update()
        {
            //Check to see if any of the the objects have gone off screen

            //List<GameObject> ObjectsToDestroy = new List<GameObject>();

            //foreach (GameObject hill in HillPieces)
            //{
            //    if (this.transform.localPosition.x < -1.5f)
            //    {
            //        //Destroy();
            //        Debug.Log("INVIS");
            //    }
            //    //// if (Camera.m > hill.transform.localPosition)
            //    // {

            //    // }
            //}
            ////ApplyMotion(0);


            GroundList.CheckForOffscreenObjects();
            MountainList.CheckForOffscreenObjects();
            RoadList.CheckForOffscreenObjects();
            HillList.CheckForOffscreenObjects();
            GrassList.CheckForOffscreenObjects();


        }

        public List<GameObject> CreateObjects(int amount, string objectLocation, GameObject Object_Home)
        {

            //Store the last sprite to use it as a reference;
            tk2dSprite lastSprite = null;

            List<GameObject> tempObjectList = new List<GameObject>();

            for (int i = 0; i < amount; i++)
            {
                GameObject tempObject = (GameObject)Instantiate(Resources.Load(objectLocation));

                tempObject.transform.parent = Object_Home.transform;

                if (lastSprite != null)
                {
                    tempObject.transform.localPosition = new Vector3(lastSprite.transform.localPosition.x + ((lastSprite.GetBounds().center.x + lastSprite.GetBounds().extents.x) * 2) -.01f , lastSprite.transform.localPosition.y, lastSprite.transform.localPosition.z);
                }

                //If object is null this is the first time around the loop do nothing besides set the last object
                lastSprite = tempObject.GetComponent<tk2dSprite>();

                tempObjectList.Add(tempObject);

            }

            return tempObjectList;
        }

        public void ApplyMotion(float amount)
        {
            MountainList.ApplyMotion(-.001f * amount);
            HillList.ApplyMotion(-.005f * amount);

            GrassList.ApplyMotion(-.01f * amount);
            GroundList.ApplyMotion(-.01f * amount);
            RoadList.ApplyMotion(-.01f * amount);



            Object_Home.transform.Translate(new Vector3(( -.01f * amount) * Time.deltaTime, 0, 0));

        }


    }
}
