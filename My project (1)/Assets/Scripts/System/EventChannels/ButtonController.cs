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

    public void MudarCorVermelho()
    {
        MudaCorEspecifica(Color.red);
    }
    public void MudarCorAzul()
    {
        MudaCorEspecifica(Color.blue);
    }
    public void MudarCorGreen()
    {
        MudaCorEspecifica(Color.green);
    }
    
    public void MudaCorEspecifica(Color corEspecifica)
    {
        specificColorEvent.RaiseEvent(corEspecifica);
    }
}
