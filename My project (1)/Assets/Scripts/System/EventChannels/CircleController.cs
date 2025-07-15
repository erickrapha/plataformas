using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class CircleController : MonoBehaviour
{
    public BulletController bulletPrefab;
    public float speed = 5.0f;
    public SpriteRenderer spriteRenderer;
    
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

    private void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        }

        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
        {
            transform.position += Vector3.left * (speed * Time.deltaTime);
        }
        if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
        {
            transform.position += Vector3.right * (speed * Time.deltaTime);
        }
        if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed)
        {
            transform.position += Vector3.up * (speed * Time.deltaTime);
        }
        if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed)
        {
            transform.position += Vector3.down * (speed * Time.deltaTime);
        }
    }
}
