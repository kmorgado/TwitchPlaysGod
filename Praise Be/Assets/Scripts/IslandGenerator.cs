
using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace AssemblyCSharp
{
	public class IslandGenerator : MonoBehaviour
	{
		public GameObject IslandBounds;


		public Building Temple;
		public Building Store;
		public Building Factory;

		//HACK
		public List<GameObject> TreeAvoidList = new List<GameObject>();

		private long iterCount;
		public GameObject TreeParent;
		private List<GameObject> TreeCollection = new List<GameObject>();
		private float scale = 50.0f;

		public int minTreeCount;
		public int maxTreeCount;


        public GameObject PeopleParent;
        private List<GameObject> PeopleCollection = new List<GameObject>();

        public int minPeopleCount;
        public int maxPeopleCount;


        public List<Color> skinColors;

		void Start ()
		{
			iterCount = 0;
			minTreeCount = 25;
			maxTreeCount = 200;

			GenerateTrees(5);
            GeneratePeople(2);
		}

		private int GetDesiredTreeCount()
		{
			// If we have no people, we have lots of trees
			// If we have people, we have few trees
			return (int)(maxTreeCount - (maxTreeCount - minTreeCount) * (StatTracker.Instance.population/StatTracker.Instance.maxpopulation));
		}

		private void SetTreeCount(int desiredCount)
		{
			Debug.Log(String.Format("SET TREE COUNT {0}", desiredCount));
			int maxTreeChange = 5;


			if (TreeCollection.Count > desiredCount)
			{
				int change = TreeCollection.Count - desiredCount;
				if (change > maxTreeChange) change = maxTreeChange;
				for (int i = 0; i < change; ++i)
				{
					GameObject.Destroy (TreeCollection[i]);
				}
				TreeCollection.RemoveRange(0, change); 
			}
			else
			{
				int change = desiredCount - TreeCollection.Count;
				if (change > maxTreeChange) change = maxTreeChange;
				GenerateTrees (change);
			}
		}

		void Update()
        {
            if (Input.GetKeyDown(KeyCode.P))
                GeneratePeople(2);
            if (Input.GetKeyDown(KeyCode.O))
                RemovePerson();


            //StatTracker.Instance.population / 
            float popRange = (StatTracker.Instance.maxpopulation - 100.0f);
            float normalized = (StatTracker.Instance.population - 100.0f) / popRange;

            int peopleRange = (maxPeopleCount - minPeopleCount);

            //int normalizeRange = popRange / peopleRange;

            int currentPeopleCount = Convert.ToInt32((peopleRange * normalized) + minPeopleCount);

            if (PeopleCollection.Count < currentPeopleCount && PeopleCollection.Count < maxPeopleCount)
                GeneratePeople(1);
            else if (PeopleCollection.Count > currentPeopleCount || PeopleCollection.Count > maxPeopleCount)
            {
                RemovePerson();
            }
            //  PeopleCollection.Count
            //  int currentPeopleCount =

            // popRange (-StatTracker.Instance.population) * (maxPeopleCount - StatTracker.Instance.maxpopulation);

            //1000000


            //The Temple is the main faith object and levels up as faith grows

            PolygonCollider2D bounds = IslandBounds.GetComponent<PolygonCollider2D>();

            foreach (GameObject go in TreeCollection)
            {
                if (go.GetComponent<BoxCollider2D>().IsTouching(bounds) == false)
                {
                    //TreeCollection.Remove (go);
                    //GameObject.Destroy (go);
                    go.SetActive(false);
                }
                else
                {
                    foreach (GameObject avd in TreeAvoidList)
                    {
                        if (go.GetComponent<BoxCollider2D>().IsTouching(avd.GetComponent<Collider2D>()))
                        {
                            //Debug.Log(avd.name);
                            //TreeCollection.Remove (go);
                            //GameObject.Destroy (go);
                            //continue;
                            go.SetActive(false);
                        }
                    }
                }

                if (go.transform.localScale.x == 1)
                    go.transform.localScale = new Vector3(scale, scale, scale);

            }

            if ((iterCount % 100) == 0)
                SetTreeCount(GetDesiredTreeCount());

            iterCount++;
        }



		void GenerateTrees(int numToGenerate)
		{

			for(int i = 0; i < numToGenerate; i++)
			{
				// create sprite
				Texture2D tex = Resources.Load<Texture2D>(System.String.Format("Nature/Tree{0}", UnityEngine.Random.Range(1, 8))) as Texture2D;

				PolygonCollider2D bounds = IslandBounds.GetComponent<PolygonCollider2D>();

				Vector3 pos = GetPointInCollider(bounds);

				// create gameobject
				GameObject go = AddSprite(tex);
				go.name = "Tree";

				go.AddComponent<BoxCollider2D>();

				go.AddComponent<Rigidbody2D>();

				go.GetComponent<BoxCollider2D>().isTrigger = true;
				go.GetComponent<Rigidbody2D>().isKinematic = true;

				//temp.

				go.transform.parent = TreeParent.transform;
				go.transform.position = pos;
				go.transform.localScale = new Vector3(1, 1, 1);

                TreeCollection.Add(go);
			}
		}

        void GeneratePeople(int numToGenerate)
        {
            for (int i = 0; i < numToGenerate; i++)
            {
                GameObject tempPerson = Instantiate(Resources.Load("Person", typeof(GameObject))) as GameObject;

                tempPerson.transform.parent = PeopleParent.transform;
                tempPerson.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
                tempPerson.transform.localPosition = new Vector3(0, 0, 0);
                tempPerson.GetComponent<Image>().color = skinColors[UnityEngine.Random.Range(0, skinColors.Count - 1)];

                PeopleCollection.Add(tempPerson);
            }
        }

        void RemovePerson()
        {
            if (PeopleCollection.Count > 0)
            {
                GameObject del = PeopleCollection[0];
                PeopleCollection.RemoveAt(0);
                GameObject.Destroy(del);
            }            
        }

        // Vector3 GenerateRandomIslandPosition()
        //{
        //Vector3 randPos = new Vector3();


        //}


        /// <summary>
        /// Returns a random world point inside the given BoxCollider
        /// </summary>
        public static Vector3 GetPointInCollider(PolygonCollider2D area)
		{
			var bounds = area.bounds;
			var center = bounds.center;

			var x = UnityEngine.Random.Range(center.x - bounds.extents.x, center.x + bounds.extents.x);
			var y = UnityEngine.Random.Range(center.y - bounds.extents.y, center.y + bounds.extents.y);

			return new Vector3(x, y, 0);
		}



		public GameObject AddSprite(Texture2D tex)
		{
			Texture2D _texture = tex;
			Sprite newSprite = Sprite.Create(_texture, new Rect(0f, 0f, _texture.width, _texture.height), new Vector2(0.5f, 0.5f), 128f);
			
			GameObject sprGameObj = new GameObject();


			sprGameObj.AddComponent<SpriteRenderer>();
			//sprite.scale = new Vector3(sprite.scale.x * scale, sprite.scale.y * scale, sprite.scale.z);
			
			SpriteRenderer sprRenderer = sprGameObj.GetComponent<SpriteRenderer>();
			sprRenderer.sprite = newSprite;
			sprRenderer.sortingOrder = 1;
			return sprGameObj;
		}




	}
}

