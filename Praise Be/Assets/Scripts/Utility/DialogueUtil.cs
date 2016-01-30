using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace Assets.Scripts.Utility
{

    public class DialogueUtil
    {
        private bool _conversationActive = false;

        #region Singleton init

        private static volatile DialogueUtil instance;
        private static object syncRoot = new System.Object();

        private DialogueUtil() { }

        public static DialogueUtil Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new DialogueUtil();
                    }
                }

                return instance;
            }
        }

        #endregion

        /// <summary>
        /// This methods starts a conversation if the distance from a player to an npc is less then the param "distance"
        /// </summary>
        /// <param name="name">name of the conversation</param>
        /// <param name="distance">distance player to npc</param>
        /// <param name="player">transform of the player</param>
        /// <param name="npc">transform of npc</param>
        public void StartConversationForDistance(string name, float distance, Transform player, Transform npc)
        {
            float dist = Vector3.Distance(player.position, npc.position);

            // We are near the monster => monster introduces himself
            if (dist < distance)
            {
                if (!_conversationActive)
                {
                    DialogueManager.StartConversation(name);

                    _conversationActive = true;
                }
            }
            else
            {
                _conversationActive = false;
            }
        }
    }
}
