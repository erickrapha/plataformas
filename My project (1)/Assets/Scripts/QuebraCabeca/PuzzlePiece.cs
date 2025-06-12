using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    public bool IsCorrectlyPlaceb { get; private set; }
    
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
