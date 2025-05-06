using System.Collections;
using UnityEngine;
using TMPro;

public class DialoguePresenter : MonoBehaviour
{
    [SerializeField] private Canvas dialgueCanvas;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private Key[] keys;
    [SerializeField] private Door[] doors;
    [SerializeField] private float dialogueTime;
    [SerializeField] private string startDialogue;

    private void OnEnable()
    {
        foreach(Key key in keys)
        {
            key.onKeyGot += HandleDialogueUpdate;
        }

        foreach(Door door in doors)
        {
            door.onDoorLocked += HandleDialogueUpdate;
        }
    }

    private void Start()
    {
        StartCoroutine(UpdateDialogue(startDialogue));
    }

    private void OnDisable()
    {
        foreach(Key key in keys)
        {
            key.onKeyGot += HandleDialogueUpdate;
        }

        foreach(Door door in doors)
        {
            door.onDoorLocked += HandleDialogueUpdate;
        }
    }

    private void HandleDialogueUpdate(string text)
    {
        StartCoroutine(UpdateDialogue(text));
    }

    private IEnumerator UpdateDialogue(string text)
    {
        dialogueText.text = text;
        dialgueCanvas.gameObject.SetActive(true);

        yield return new WaitForSeconds(dialogueTime);

        dialgueCanvas.gameObject.SetActive(false);
    }
}
