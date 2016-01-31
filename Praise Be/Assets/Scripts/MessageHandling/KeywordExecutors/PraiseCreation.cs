using UnityEngine;
using System.Collections;

public class PraiseCreation : GameExecutor {

    public int creationBoon = 2;
    public int excessBoon = 1;
    public int deathBoon = 0;

    override public void Execute(Executor.Message message) {
        statTracker.currentCreationGodValue += creationBoon;
        statTracker.currentDeathGodValue += deathBoon;
        statTracker.currentExcessGodValue += excessBoon;

        this.LogDebug(message.from + " praises CREATION! (" + message.message + ")");
    }
}
