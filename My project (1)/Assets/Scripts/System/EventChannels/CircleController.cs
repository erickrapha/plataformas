using UnityEngine;

public class CircleController : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    
    [Header("Listening on...")]
    public VoidEventChannel circleColorEvent;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        circleColorEvent.OnEventRaised += MudaCor;
    }
    private void OnDisable()
    {
        circleColorEvent.OnEventRaised -= MudaCor;
    }
    public void MudaCor()
    {
        spriteRenderer.color = Random.ColorHSV();
    }
}
