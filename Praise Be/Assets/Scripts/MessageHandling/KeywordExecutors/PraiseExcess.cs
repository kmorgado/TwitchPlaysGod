using UnityEngine;
using System.Collections;

public class PraiseExcess : GameExecutor {
    public int creationBoon = 0;
    public int excessBoon = 2;
    public int deathBoon = 1;

    override public void Execute(Executor.Message message) {
        statTracker.currentCreationGodValue += creationBoon;
        statTracker.currentDeathGodValue += deathBoon;
        statTracker.currentExcessGodValue += excessBoon;

        this.LogDebug(message.from + " praises EXCESS! (" + message.message + ")");
    }
}
