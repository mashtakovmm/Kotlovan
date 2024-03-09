using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUIManager : MonoBehaviour
{
    [Header("Listening to:")]
    // [SerializeField] private SimpleNodeSOEventChannelSO simpleNodeDataChannel;
    // [SerializeField] private ChoiceNodeSOEventChannelSO choiceNodeDataChannel;
    [SerializeField] SimpleNodeDataChannelSO simpleNodeDataChannel;
    [SerializeField] ChoiceNodeDataChannelSO choiceNodeDataChannel;
    [Header("Broadcasting to:")]
    [SerializeField] BaseNodeSOChannel nextNodeCallbackChannel;

    [Header("Components")]
    [SerializeField] private GameObject speakerNameUI;
    [SerializeField] private GameObject dialogueTextUI;
    [SerializeField] private GameObject optionsContainer;
    [SerializeField] private GameObject optionButtonPrefab;

    private void OnEnable()
    {
        simpleNodeDataChannel.OnSimpleNodeDataRequested += HandelSimpleNodeData;
        choiceNodeDataChannel.OnChoiceNodeDataRequested += HandleChoiceNodeData;
    }

    private void OnDisable()
    {
        simpleNodeDataChannel.OnSimpleNodeDataRequested -= HandelSimpleNodeData;
        choiceNodeDataChannel.OnChoiceNodeDataRequested -= HandleChoiceNodeData;
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

    private void HandleChoiceNodeData(DialogueLineSO line, DialogueSpeakerSO speaker, OptionsSO[] options)
    {
        Color lineColor = line.Color;
        Color speakerColor = speaker.Color;

        string lineText = line.Text;
        string speakerName = speaker.SpeakerName;

        speakerNameUI.GetComponent<TMP_Text>().text = speakerName;
        speakerNameUI.GetComponent<TMP_Text>().color = speakerColor;
        dialogueTextUI.GetComponent<TMP_Text>().text = lineText;
        dialogueTextUI.GetComponent<TMP_Text>().color = lineColor;


        // TODO: change the logic. I dont like handling the node in this component, all node logic should be handeled in DialogueManager.
        // Leave it for now as is
        foreach (OptionsSO option in options)
        {
            GameObject newButton = Instantiate(optionButtonPrefab, optionsContainer.transform);
            newButton.GetComponentInChildren<TMP_Text>().text = option.OptionText;

            // THIS IS THE PROBLEM
            newButton.GetComponent<Button>().onClick.AddListener(() => HandleOnClick(option.NextNode));
        }
    }

    private void HandleOnClick(BaseNodeSO nextNode)
    {
        nextNodeCallbackChannel.OnBaseNodeSOEventRequested(nextNode);

        // clear container
        foreach (Transform child in optionsContainer.transform)
        {
            Destroy(child.gameObject);
        }
    }
}
