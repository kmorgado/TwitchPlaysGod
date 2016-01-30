using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace Assets.Scripts.Utility
{
    class NarrationRender : MonoBehaviour
    {
        //public UILabel NarrationText;
        public float renderDelay = 0.05f;

		//The amount of time to render the text after its done.
		public float textDisplayTime = 2.0f;


        void Start()
        {
            //DialogueManager.StartConversation("Test");

            //NarrationText = GameObject.Find("NarrationText").GetComponent<UILabel>();
            //StartCoroutine(RenderText("THIS IS A TEST OF THE NATIONAL BROADCASTING SYSTEM"));

        }


        void Update()
        {
        }


        //This function renders a sentance one character at a time
        IEnumerator RenderText(string textToRender)
        {
            string tempRenderText = "";



			//NarrationText.text = textToRender;
		    //int lineCount = GetLineCount(NarrationText);

			//textToRender = NarrationText.processedText;

            //Start with nothing 
           // NarrationText.text = tempRenderText;

			//First we must measure the width of the text in comparision to the final box.

			 
            for (int i = 0; i < textToRender.Count(); i++)
            {
                tempRenderText += textToRender[i];

               // NarrationText.text = tempRenderText;

                yield return new WaitForSeconds(renderDelay);
            }

				yield return new WaitForSeconds(textDisplayTime);

				//NarrationText.text  = "";

        }

        //int GetLineCount(UILabel label)
        //{
        //    return label.processedText.Split('\n').Length - 1;
        //}


    }
}
