using UnityEngine.UI;
using UnityEngine;

public class SemRefrigerante : StateMachineBehaviour
{
    [SerializeField] private string vazio = "Vazio";

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameObject obj = GameObject.Find(vazio);
        if (obj != null)
        {
            obj.SetActive(true);
            Debug.Log("Text ativado" + vazio);
        }
        else
        {
            Debug.LogWarning("Text desativado" + vazio);
        }
    }
}
