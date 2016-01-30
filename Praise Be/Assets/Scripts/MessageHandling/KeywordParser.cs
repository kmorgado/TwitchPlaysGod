using Irc;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeywordParser : MonoBehaviour {
    [Serializable]
    public class KeywordAssociation {
        public string key;
        public Executor executor;
    } 

    public Executor gameLogicExecutor = null;
    public List<KeywordAssociation> keywordLogicAssociation = new List<KeywordAssociation>();

    public void OnMessageReceived(Executor.Message message) {
        Boolean messageHandled = false;

        string messageContents = message.message;
        foreach(KeywordAssociation association in keywordLogicAssociation) {
            if(messageContents.StartsWith(association.key)) {
                association.executor.Execute(message);
                messageHandled = true;
                break;
            }
        }

        if (messageHandled == false && gameLogicExecutor != null) {
            gameLogicExecutor.Execute(message);
        }
    }
}
