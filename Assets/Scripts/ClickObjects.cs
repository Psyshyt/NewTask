using UnityEngine;
using UnityEngine.EventSystems;

public class ClickObjects : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Игра началась");
    }
}

