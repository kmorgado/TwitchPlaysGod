﻿using System;

using UnityEngine;
using System.Collections;

public class PraiseDeath : GameExecutor {

    public int creationBoon = 1;
    public int excessBoon = 0;
    public int deathBoon = 2;

    override public void Execute(Executor.Message message) {
        statTracker.currentCreationGodValue += creationBoon;
        statTracker.currentDeathGodValue += deathBoon;
        statTracker.currentExcessGodValue += excessBoon;
        this.LogDebug(message.from + " praises DEATH! (" + message.message + ")");
    }
}