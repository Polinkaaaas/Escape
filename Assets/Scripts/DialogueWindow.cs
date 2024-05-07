using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Dialogue
{
    public class DialogueWindow: MonoBehaviour
    {
        private TMP_Text _text;
        private DialogueStory _dialogueStory;
        
           /* _text = GetComponent<TMP_Text>();
            _dialogueStory = FindObjectOfType<DialogueStory>();
            _dialogueStory.ChangedStory += ChangeAnswers;
            */
           private void Awake()
           {
               _text = GetComponent<TMP_Text>();
               if (_text == null) Debug.LogError("TMP_Text component is missing on the object.");

               _dialogueStory = FindObjectOfType<DialogueStory>();
               if (_dialogueStory == null) Debug.LogError("DialogueStory component is missing in the scene.");

               _dialogueStory.ChangedStory += ChangeAnswers;
           }

        private void ChangeAnswers(DialogueStory.Story story) => _text.text = story.Text;
    }
}