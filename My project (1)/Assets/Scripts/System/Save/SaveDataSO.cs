using UnityEngine;

[CreateAssetMenu(fileName = "SaveDataSO", menuName = "Scriptable Objects/SaveDataSO")]
public class SaveDataSO : ScriptableObject
{
    public Color circleColor;

    public string SaveDataToJson()
    {
        return JsonUtility.ToJson(this);
    }
    public void LoadDataFromJson(string json)
    {
        JsonUtility.FromJsonOverwrite(json, this);
    }
}
