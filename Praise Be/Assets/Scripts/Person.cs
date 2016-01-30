using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Person : MonoBehaviour {

    public Image personImage;
    public float moveChancePct;
    
	// Use this for initialization
	void Start () {
        moveChancePct = 0.3f;
	}
	
	// Update is called once per frame
	void Update () {
	    if (Random.Range(0.0f,1.0f) > moveChancePct)
        {
            MoveRandom();
        }
	}

    private void MoveRandom()
    {
        switch (Random.Range(0,4))
        {
            case 0:
                // Move up
                break;
            case 1:
                // Move down
                break;
            case 2:
                // Move left
                break;
            case 3:
                // Move right
                break;
        }
    }
}
