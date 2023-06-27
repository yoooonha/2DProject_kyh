using UnityEngine;

public class Zone : MonoBehaviour
{
    public bool follow;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        follow = true;
       
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        follow = false;
    }
}
