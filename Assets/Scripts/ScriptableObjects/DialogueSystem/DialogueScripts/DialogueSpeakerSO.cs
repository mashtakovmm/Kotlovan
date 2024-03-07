using UnityEngine;

[CreateAssetMenu(menuName = "DialogueSystem/DialogueSpeaker")]
public class DialogueSpeakerSO : ScriptableObject
{
    [SerializeField] private string _speakerName;
    [SerializeField] private Color _color = new Color(224, 224, 224);

    public string SpeakerName => _speakerName;
    public Color Color => _color;
}
