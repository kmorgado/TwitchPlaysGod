
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


		public GameObject TreeParent;
		private List<GameObject> TreeCollection = new List<GameObject>();
		private float scale = 50.0f;


		void Start ()
		{
			GenerateTrees(150);
		}

		void Update()
		{
			//The Temple is the main faith object and levels up as faith grows

			PolygonCollider2D bounds = IslandBounds.GetComponent<PolygonCollider2D>();

			foreach(GameObject go in TreeCollection)
			{
				//if(go.GetComponent<BoxCollider2D>().IsTouching(bounds) == false)
					//go.SetActive(false);
			}
		}



		void GenerateTrees(int numToGenerate)
		{
			for(int i = 0; i < numToGenerate; i++)
			{
				//string treeName = cloudSpriteNames[Random.Range(0, 5)];
				
				// create sprite
				Texture2D tex = Resources.Load<Texture2D>(System.String.Format("Nature/Tree{0}", UnityEngine.Random.Range(1, 8))) as Texture2D;

				PolygonCollider2D bounds = IslandBounds.GetComponent<PolygonCollider2D>();

				Vector3 pos = GetPointInCollider(bounds);

					//new Vector3(UnityEngine.Random.Range(-400, 400), UnityEngine.Random.Range(0, 400), 1);
				
				
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
				go.transform.localScale = new Vector3(scale, scale, scale);





				TreeCollection.Add(go);
				//else
				//	go.SetActive(false);
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

