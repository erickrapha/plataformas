using UnityEngine;

public class ButtonController : MonoBehaviour
{
    [Header("Broadcasting on...")]
    public VoidEventChannel circleColorEvent;
    public ColorEventChannel specificColorEvent;

    public void MudaCor()
    {
        circleColorEvent.RaiseEvent();
    }
    public void MudaCorEspecific(Color corEspecific)
    {
        specificColorEvent.RaiseEvent(corEspecific);
    }
}
