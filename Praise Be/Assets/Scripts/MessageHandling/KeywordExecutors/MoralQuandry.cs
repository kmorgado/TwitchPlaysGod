using UnityEngine;
using System.Collections;

public class MoralQuandry : GameExecutor {
    override public void Execute(Executor.Message message) {
        if(message.message.ToLower().Contains("yes")) {
            statTracker.yesCount += 1; 
        } else if (message.message.ToLower().Contains("no")) {
            statTracker.noCount += 1; 
        }
    }
}
