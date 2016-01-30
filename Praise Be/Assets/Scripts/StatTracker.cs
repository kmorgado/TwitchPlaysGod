using UnityEngine;
using System.Collections;

public class StatTracker : MonoBehaviour {

    // Stats:
    // Doubles probably make the most sense

    // Stats based directly on user input
    // Faith
    public double faithValue;
    // Viewer count - being optimistic ;)
    public long viewerCount;

    // So 3 gods, to start just a raw stat for each
    public double lifeGodValue;
    public double deathGodValue;
    public double chaosGodValue;

    // Rando
    public float anarchyValue;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}


}
