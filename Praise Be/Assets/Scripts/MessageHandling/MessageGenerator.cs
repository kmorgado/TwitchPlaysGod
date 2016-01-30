using UnityEngine;

public class MessageGenerator : MonoBehaviour
{
    public KeywordParser keywordParser = null;


    public void OnMessageReceived(Executor.Message message) { 
        keywordParser.OnMessageReceived(message);
    }
}

