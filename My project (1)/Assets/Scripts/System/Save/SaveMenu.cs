using UnityEngine;

public class SaveMenu : MonoBehaviour
{
    public CircleController playerCircle;

    public void SaveSO()
    {
        SaveManager.Instance.saveData.SaveCircleColor(playerCircle.spriteRenderer.color);
    }

    public void LoadSO()
    {
        playerCircle.spriteRenderer.color = SaveManager.Instance.saveData.circleColor;
    }

    public void SaveFile()
    {
        SaveManager.Instance.WriteSaveToFile();
    }

    public void LoadFile()
    {
        SaveManager.Instance.LoadSaveFromFile();
        LoadSO();
    }
}
