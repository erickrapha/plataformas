using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    public static bool IsCorrectlyPlaceb;
    public bool IsCorrectlyPlaced { get; set; }

    public void SetCorrectlyPlaceb(bool isPlaceb)
    {
        IsCorrectlyPlaceb = isPlaceb;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("CorrectPosition"))
        {
            SetCorrectlyPlaceb(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("CorrectPosition"))
        {
            SetCorrectlyPlaceb(false);
        }
    }
}
