using TMPro;
using UnityEngine;

public class DialogueUIManager : MonoBehaviour
{
    [Header("Listening to:")]
    // [SerializeField] private SimpleNodeSOEventChannelSO simpleNodeDataChannel;
    // [SerializeField] private ChoiceNodeSOEventChannelSO choiceNodeDataChannel;
    [SerializeField] SimpleNodeDataChannelSO simpleNodeDataChannel;

    [Header("Components")]
    [SerializeField] private GameObject speakerNameUI;
    [SerializeField] private GameObject dialogueTextUI;

    private void Start()
    {
        speakerNameUI.GetComponent<TMP_Text>().text = "aaaaaaaaa";
    }

    private void OnEnable()
    {
        simpleNodeDataChannel.OnSimpleNodeDataRequested += HandelSimpleNodeData;
    }

    private void OnDisable()
    {
        simpleNodeDataChannel.OnSimpleNodeDataRequested -= HandelSimpleNodeData;
    }

    private void HandelSimpleNodeData(DialogueLineSO line, DialogueSpeakerSO speaker)
    {
        Color lineColor = line.Color;
        Color speakerColor = speaker.Color;

        string lineText = line.Text;
        string speakerName = speaker.SpeakerName;

        speakerNameUI.GetComponent<TMP_Text>().text = speakerName;
        speakerNameUI.GetComponent<TMP_Text>().color = speakerColor;
        dialogueTextUI.GetComponent<TMP_Text>().text = lineText;
        dialogueTextUI.GetComponent<TMP_Text>().color = lineColor;
    }
}
