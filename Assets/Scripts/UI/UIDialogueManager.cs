using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIDialogueManager : UICanvas
{

    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;

    public GameObject continueButton;

    public override void Awake()
    {
        base.Awake();
    }

    public void StartSentences(string[] _sentences) {
        sentences = _sentences;
        continueButton.SetActive(true);
        textDisplay.text = "";
        StartCoroutine(Type());
    }

    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

    }
    public void NextSentence()
    {

        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
            continueButton.SetActive(false);
        }

    }

}
