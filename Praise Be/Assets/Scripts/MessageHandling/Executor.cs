using System;
using System.Collections;
using UnityEngine;

public class Executor : MonoBehaviour {
    [Serializable]
    public class Message {
        public enum Type {server, channel}

        public string from;
        public string message;
        public Type type;

        override
        public string ToString() {
            return from + ": " + message;
        }
    }

    virtual public void Execute(Message message) {
        Debug.LogError("Message dropped into Executor class. This should not happen! (Message: " + message.ToString() + ")");
    }
}
