using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI TextComponent;
    public string[] lines;
    public float TextSpeed;

    private int index;
    void Start()
    {
        TextComponent.text = string.Empty;
        StartDialogue();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (TextComponent.text == lines[index])
            {
                NextLine();
            }
            else
            { 
                StopAllCoroutines();
                TextComponent.text = lines[index];
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    { 
        foreach (char c in lines[index].ToCharArray()) 
        {
            TextComponent.text += c;
            yield return new WaitForSeconds(TextSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            TextComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
