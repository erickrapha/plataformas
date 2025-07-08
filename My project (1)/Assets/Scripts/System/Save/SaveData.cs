using UnityEngine;

public class SaveData : MonoBehaviour
{
    public SaveDataSO saveDataSo;
    public Color circleColor => saveDataSo.circleColor;

    public void SaveCircleColor(Color color)
    {
        saveDataSo.circleColor = color;
    }
}
