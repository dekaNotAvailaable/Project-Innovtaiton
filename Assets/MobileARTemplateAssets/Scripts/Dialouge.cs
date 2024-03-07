using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public float textSpeed;
    private int dialogueIndex;
    private bool isTyping;
    private string[] currentLines;
    private LevelChange changeLevel;
    public string levelName;
    // Start is called before the first frame update
    void Start()
    {
        changeLevel = FindAnyObjectByType<LevelChange>();
        StartDialogue();
    }
    public void Button1Clicked()
    {
        NextLine();
        if (dialogueIndex >= OriginalLines().Length) { StartCoroutine(EndDialouge()); }
    }
    void StartDialogue()
    {
        dialogueIndex = 0;
        currentLines = OriginalLines();
        StartCoroutine(TypeLine());
    }
    IEnumerator EndDialouge()
    {
        yield return new WaitForSeconds(1f);
        Debug.Log("End dialouge");
        changeLevel.NextScene(levelName);
    }

    IEnumerator TypeLine()
    {
        if (dialogueIndex < currentLines.Length)
        {
            textComponent.text = string.Empty;
            foreach (char c in currentLines[dialogueIndex].ToCharArray())
            {
                textComponent.text += c;
                yield return new WaitForSeconds(textSpeed);
                isTyping = true;
            }
            dialogueIndex++;
            isTyping = false;
            Debug.Log("index plus plus");
        }
    }
    void NextLine()
    {
        if (dialogueIndex <= currentLines.Length)
        {
            StartCoroutine(TypeLine());

        }
        // else
        // {
        //   gameObject.SetActive(false);
        //}
    }
    private string[] OriginalLines()
    {
        return new string[]
        {
            "To make a potion you need to find colors that you see here in real life.",
            "You need to find red, green and blue colors and then take a photo of them.",
        };
    }
}
