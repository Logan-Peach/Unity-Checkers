using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LearningModeTextScript : MonoBehaviour
{
    [SerializeField] private Text learnText;
    void Update()
    {
        if (StartScript.learningMode)
        {
            learnText.text = "Learning Mode: Enabled";
        }
        else
        {
            learnText.text = "Learning Mode: Disabled";
        }
    }
}
