using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed;
    public Vector2 direction;

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
