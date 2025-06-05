using Unity.VisualScripting;
using UnityEngine;

public class Door : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        if (OnDestroy == true)
        {
            EventManager.PlayerPisando();
            Destroy(this.gameObject);
        }
    }
    public bool OnDestroy { get; set; }
}
