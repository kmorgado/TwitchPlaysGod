using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CloudEffect : MonoBehaviour
{

	public int GenerateXNumberOfClouds;
	//y
	public float MinY = 2.4f;
	public float MaxY = 3.2f;
	//x
	public float MinX = -6;
	public float MaxX = 0;

	public float scale = 1.0f;

	//Link in the Sky Sprite Collection	
    //tk2dSpriteCollectionData cloudCollection;

    List<GameObject> cloudArrayLeft;
    //List<Sprite> cloudArrayRight;
	List<float> cloudSpeed;

	string[] cloudSpriteNames = { "PUN_GEN_CloudL", "PUN_GEN_CloudM", "PUN_GEN_CloudS", "PUN_GEN_CloudFat", "PUN_GEN_CloudLong" };

	// Use this for initialization
	void Start()
	{

	}


	void Awake()
	{
        GameObject parent = GameObject.Find("CloudGroup");
		//parent.name = "CloudGroup";

        cloudArrayLeft = new List<GameObject>();
        //cloudArrayRight = new List<Sprite>();
		cloudSpeed = new List<float>();

		//Generate Clouds Starting on the left moving right
		for (int i = 0; i < GenerateXNumberOfClouds / 2; ++i)
		{
			//System.Random rnd = new System.Random();
            string cloudName = cloudSpriteNames[Random.Range(0, 5)];

            // create sprite
            Texture2D tex = Resources.Load<Texture2D>(System.String.Format("Clouds/{0}", cloudName)) as Texture2D;

            Vector3 pos = new Vector3(Random.Range(MinX, MaxX), Random.Range(MinY, MaxY), 1);


            // create gameobject
			GameObject go = AddSprite(tex);
            go.name = cloudName;
            go.transform.parent = parent.transform;
            go.transform.localPosition = pos;
            go.transform.localScale = new Vector3(scale, scale, scale);


            cloudArrayLeft.Add(go);
			cloudSpeed.Add(Random.Range(2f, 6f));
		}

        ////Generate Clouds Starting on the right moving left
        //for (int i = 0; i < GenerateXNumberOfClouds / 2; ++i)
        //{

        //    string cloudName = cloudSpriteNames[Random.Range(0, 5)];

        //    GameObject go = new GameObject();
        //    go.name = cloudName;

        //    Vector3 pos = new Vector3(Random.Range(MinX, MaxX), Random.Range(MinY, MaxY), Random.Range(4, 6));


        //    tk2dSprite sprite = go.AddComponent<tk2dSprite>();

        //    // assign sprite collection and sprite Id for this batched sprite
        //    sprite.Collection = cloudCollection;
        //    sprite.spriteId = cloudCollection.GetSpriteIdByName(cloudName);
        //    sprite.transform.position = pos;
        //    sprite.scale = new Vector3(sprite.scale.x * scale, sprite.scale.y * scale, sprite.scale.z);


        //    cloudArrayRight.Add(sprite);

        //    go.transform.parent = parent.transform;

        //    cloudSpeed.Add(Random.Range(-.02f, -.06f));

        //}

	}


	// Update is called once per frame
	void Update()
	{

		
		//Left Cloud Update
		for (int i = 0; i < cloudArrayLeft.Count; ++i)
		{

			cloudArrayLeft[i].transform.Translate(new Vector3(cloudSpeed[i] * Time.deltaTime, 0, 0));

			if (cloudArrayLeft[i].transform.position.x > MaxX)
				cloudArrayLeft[i].transform.position = new Vector3(Random.Range(MinX, MinX + 2), cloudArrayLeft[i].transform.position.y, cloudArrayLeft[i].transform.position.z);
		}

		//Right Cloud Update
        //for (int i = 0; i < cloudArrayRight.Count; ++i)
        //{

        //    cloudArrayRight[i].transform.Translate(new Vector3(cloudSpeed[i + cloudArrayLeft.Count] * Time.deltaTime, 0, 0));

        //    if (cloudArrayRight[i].transform.position.x < MinX)
        //        cloudArrayRight[i].transform.position = new Vector3(Random.Range(MaxX - 2, MaxX), cloudArrayRight[i].transform.position.y, cloudArrayRight[i].transform.position.z);

        //}
		


	}

	IEnumerator Sleep(float time)
	{
		yield return new WaitForSeconds(time);
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
        return sprGameObj;
    }



}


/*
		if(cloudBatcher != null)
		{
	
	//Itterate through all the clouds moving them every frame
	
			for (int i = 0; i < cloudBatcher.batchedSprites.Length; ++i) {
	
				Vector3 oldPos = cloudBatcher.batchedSprites[i].position;
			
				oldPos.x += Time.deltaTime * 100;
				
				
				cloudBatcher.batchedSprites[i].position = oldPos;
			}
			
			cloudBatcher.UpdateMatrices();
			
		} 
  */