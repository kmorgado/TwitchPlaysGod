using System;
using UnityEngine;

public class GameExecutor : Executor
{
    // This class will act as the "catch all" executor with ties to the game logic.
    // 
    // There should only be one scene! 

    public StatTracker statTracker = null;

    override
    public void Execute(Message message) {
        LogDebug("No impl: (" + message.ToString() + ")");
    }

    protected void LogDebug(string message) {
        Debug.Log(message);
    }
}

