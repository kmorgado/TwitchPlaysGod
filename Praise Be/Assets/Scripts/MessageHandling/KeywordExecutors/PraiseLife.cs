using UnityEngine;
using System.Collections;

public class PraiseLife : GameExecutor {
    override public void Execute(Executor.Message message) {
        this.LogDebug(message.from + " praises LIFE! (" + message.message + ")");
    }
}
