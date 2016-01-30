using System;

using UnityEngine;
using System.Collections;

public class PraiseDeath : GameExecutor {
    override public void Execute(Executor.Message message) {
        this.LogDebug(message.from + " praises DEATH! (" + message.message + ")");
    }
}