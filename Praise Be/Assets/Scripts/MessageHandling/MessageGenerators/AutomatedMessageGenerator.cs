using Irc;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomatedMessageGenerator : MessageGenerator
{
    [Serializable]
    public class TimedMessage {
        public float delayInSeconds = 0;
        public Executor.Message message;
    }

    public List<TimedMessage> messageList = new List<TimedMessage>();

    public void Update() {
        timeSinceLastMessage += Time.deltaTime;

        while(messageList.Count > 0) {
            if(messageList[0].delayInSeconds < timeSinceLastMessage) {
                this.OnMessageReceived(messageList [0].message);

                timeSinceLastMessage = timeSinceLastMessage - messageList [0].delayInSeconds;
                messageList.RemoveAt(0);
            } else {
                break;
            }
        }
    }

    private float timeSinceLastMessage = 0;
}
