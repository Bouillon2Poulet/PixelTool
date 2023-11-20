using UnityEngine;
using UnityEngine.EventSystems;

public class mode_button : MonoBehaviour, IPointerClickHandler
{
    // Start is called before the first frame update
    void Start()
    {
    }
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        //Use this to tell when the user left-clicks on the Button
        if (pointerEventData.button == PointerEventData.InputButton.Left)
        {
            GetComponentInParent<mode_manager>().swapCurrentMode();
        }
    }
}
