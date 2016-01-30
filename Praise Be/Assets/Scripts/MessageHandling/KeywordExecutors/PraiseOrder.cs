using UnityEngine;
using System.Collections;

public class PraiseOrder : GameExecutor {
    override public void Execute(Executor.Message message) {
        this.LogDebug(message.from + " praises ORDER! (" + message.message + ")");
    }
}
