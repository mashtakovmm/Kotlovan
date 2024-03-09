using UnityEngine.EventSystems;
using UnityEngine.UI;


/// <summary>
/// Removes click and drag feature of ScrollRect
/// </summary>
public class ScrollViewNoClickDrag : ScrollRect
{
    public override void OnBeginDrag(PointerEventData eventData) { }
    public override void OnDrag(PointerEventData eventData) { }
    public override void OnEndDrag(PointerEventData eventData) { }
}



