using UnityEngine;
using System.Collections;
using Assets.Scripts;
using System.Collections.Generic;

public class StatTracker : Singleton<StatTracker> {

    // How many of these can we hold?
    // Fuck it, start with 256
    const int maxHistoryLength = 256;

    // We should have at least a brief history of previous gamestates (rounds)
    private Queue<StatGameState> history;
    // Current state, will be cloned and pushed into history on round end
    private StatGameState currentState;

    // Accessors for current game state
    public double currentFaithValue
    {
        get { return currentState.faithValue; }
        set { currentState.faithValue = value; }
    }
    public long currentViewerCount
    {
        get { return currentState.viewerCount; }
        set { currentState.viewerCount = value; }
    }
    public double currentLifeGodValue
    {
        get { return currentState.lifeGodValue; }
        set { currentState.lifeGodValue = value; }
    }
    public double currentDeathGodValue
    {
        get { return currentState.deathGodValue; }
        set { currentState.deathGodValue = value; }
    }
    public double currentChaosGodValue
    {
        get { return currentState.chaosGodValue; }
        set { currentState.chaosGodValue = value; }
    }
    public double currentAnarchyValue
    {
        get { return currentState.anarchyValue; }
        set { currentState.anarchyValue = value; }
    }

    // Use this for initialization
    void Start () {
        history = new Queue<StatGameState>();
	}
	
	// Update is called once per frame
	void Update () {

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
