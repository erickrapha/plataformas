using UnityEngine;

public class CircleController : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    
    [Header("Listening on...")]
    public VoidEventChannel circleColorEvent;
    public ColorEventChannel specificColorEvent;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnEnable()
    {
        circleColorEvent.OnEventRaised += MudaCor;
        specificColorEvent.OnEventRaised += MudaCorEspecifica;
    }
    private void OnDisable()
    {
        circleColorEvent.OnEventRaised -= MudaCor;
        specificColorEvent.OnEventRaised -= MudaCorEspecifica;
    }
    public void MudaCor()
    {
        spriteRenderer.color = Random.ColorHSV();
    }
    public void MudaCorEspecifica(Color corEspecifica)
    {
        spriteRenderer.color = corEspecifica;
    }
}
