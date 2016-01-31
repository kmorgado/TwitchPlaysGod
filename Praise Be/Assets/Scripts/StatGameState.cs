using UnityEngine;
using System.Collections;

public class StatGameState : MonoBehaviour {

    // So this should actually hold the game state
    // Moving to a new object to better support history

    // Stats based directly on user input
    // Faith
    public double faithValue;
    // Viewer count - being optimistic ;)
    public long viewerCount;

    // So 3 gods, to start just a raw stat for each
    public double enduranceGodValue;
    public double deathGodValue;
    public double creationGodValue;

    // Rando
    public double anarchyValue;


    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    /// <summary>
    /// Clone bitches
    /// </summary>
    /// <returns></returns>
    public StatGameState Clone()
    {
        return (StatGameState)MemberwiseClone();
    }
}
