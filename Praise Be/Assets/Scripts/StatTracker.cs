using UnityEngine;
using System.Collections;
using Assets.Scripts;
using System.Collections.Generic;

public class StatTracker : Singleton<StatTracker> {

    // How many of these can we hold?
    // Fuck it, start with 256
    const int maxHistoryLength = 256;

    public float population = 100.0f;
    public float happiness = 50.0f;

    // We should have at least a brief history of previous gamestates (rounds)
    private Queue<StatGameState> history;
    // Current state, will be cloned and pushed into history on round end
    private StatGameState currentState;

    // Accessors for current game state
    public float currentFaithValue
    {
        get { return currentState.faithValue; }
        set { currentState.faithValue = value; }
    }
    public long currentViewerCount
    {
        get { return currentState.viewerCount; }
        set { currentState.viewerCount = value; }
    }
    public float currentExcessGodValue
    {
        get { return currentState.enduranceGodValue; }
        set { currentState.enduranceGodValue = value; }
    }
    public float currentDeathGodValue
    {
        get { return currentState.deathGodValue; }
        set { currentState.deathGodValue = value; }
    }
    public float currentCreationGodValue
    {
        get { return currentState.creationGodValue; }
        set { currentState.creationGodValue = value; }
    }
    public float currentAnarchyValue
    {
        get { return currentState.anarchyValue; }
        set { currentState.anarchyValue = value; }
    }

    // Use this for initialization
    void Start () {
        history = new Queue<StatGameState>();
        currentState = new StatGameState();

        currentCreationGodValue = 33.0f;
        currentDeathGodValue = 33.0f;
        currentExcessGodValue = 33.0f;
	}
	
	// Update is called once per frame
	void Update () {
        if (population > 0) {
            float valueTotals = currentCreationGodValue + currentDeathGodValue + currentExcessGodValue;

            currentCreationGodValue = ((currentCreationGodValue / valueTotals * 100.0f));
            currentDeathGodValue = ((currentDeathGodValue / valueTotals * 100.0f));
            currentExcessGodValue = ((currentExcessGodValue / valueTotals * 100.0f));

            float lifeAverage = (currentCreationGodValue + currentDeathGodValue) * 0.5f;
            if(lifeAverage < currentCreationGodValue) {
                population = population + (population * ((currentCreationGodValue - lifeAverage) / lifeAverage));
            } else if(lifeAverage < currentDeathGodValue) {
                population = population - (population * ((currentDeathGodValue - lifeAverage) / lifeAverage));
            }

            happiness = happiness + (happiness * ((currentExcessGodValue - lifeAverage) / currentExcessGodValue));
        }
	}

    // This will get fired on a timer, this timer may come from this class
    // Or may come from the parser or the simulation
    public void EndRound()
    {
        // Invoke the simulation? or is simulation calling this?
        // At the very least push it to history
        if (history.Count == maxHistoryLength)
        {
            // Don't even care
            history.Dequeue();
        }
        history.Enqueue(currentState.Clone());

    }
}
