
using System;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Utility;
using System.Collections.Generic;

namespace AssemblyCSharp
{
	public class Building : MonoBehaviour
	{
		public Affinity buildingAffinity;
		public int currentBuildingLevel = 1;
		public Image buildingImage;

		public List<Sprite> levelImages;
		private int maxBuildingLevel;

		//public List<LevelTuple> ListOfLevels;

		
		void Start ()
		{
			maxBuildingLevel = levelImages.Count;
		}
		
		void Update()
		{
			if (Input.GetKeyDown(KeyCode.A))
				LevelUp();

			if (Input.GetKeyDown(KeyCode.S))
				LevelDown();
		}


		void LevelUp()
		{
			if(currentBuildingLevel < maxBuildingLevel)
			{				
				currentBuildingLevel++;
				buildingImage.sprite = levelImages[currentBuildingLevel - 1];
				buildingImage.SetNativeSize();
			}
		}

		void LevelDown()
		{
			if(currentBuildingLevel > 1)
			{				
				currentBuildingLevel--;
				buildingImage.sprite = levelImages[currentBuildingLevel - 1];
				buildingImage.SetNativeSize();
				
			}
		}

	}
}

