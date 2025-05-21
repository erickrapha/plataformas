using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Player), typeof(Rigidbody2D))]
public class TecladoMove : MonoBehaviour
{
    [Tooltip("Velocidade de translação em unidades por segundo")]
    public float velocity = 5f;
    [Tooltip("Velocidade de rotação em graus por segundo")]
    public float rotationSpeed = 100f;
    
    private Player player;
    private Rigidbody2D rb;
    private Transform t;

    void Start()
    {
        player = GetComponent<Player>();
        rb = GetComponent<Rigidbody2D>();
        t = transform;
    }

    void Update()
    {
        // Garante que o teclado existe (ex: em builds sem teclado, evita NRE)
        var keyboard = Keyboard.current;
        if (keyboard == null) return;
        
        // Leitura de eixos horizontal e vertical (WASD + setas)
        float moveX = 0f;
        if (keyboard.aKey.isPressed || keyboard.leftArrowKey.isPressed)  moveX = -1f;
        if (keyboard.dKey.isPressed || keyboard.rightArrowKey.isPressed) moveX =  1f;


        Vector2 direction = new Vector2(moveX, 0);
        
        // Move o transform no espaço mundial, frame‐rate independent
        t.Translate(direction * velocity * Time.deltaTime);
        
        
    }
}