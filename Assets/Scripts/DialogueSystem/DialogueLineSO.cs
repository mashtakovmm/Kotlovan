using UnityEngine;

[CreateAssetMenu(menuName = "DialogueSystem/DialogueLine")]
public class DialogueLineSO : ScriptableObject
{
    [SerializeField] private string _text;
    [SerializeField] private Color _color = new Color(224, 224, 224);

    public string Text => _text;
    public Color Color => _color;
}
