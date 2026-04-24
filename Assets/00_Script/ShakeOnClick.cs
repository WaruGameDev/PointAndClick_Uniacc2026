using UnityEngine;
using DG.Tweening;

public class ShakeOnClick : MonoBehaviour
{
    public float forceJump = 2;
    public int jumpQuantity = 3;
    public float duration = .5f;

    public bool isSuscribed;    
    void OnMouseDown()
    {
        if(isSuscribed)
        {
            ShakeManager.instance.OnShake -= Shake;
            isSuscribed =false;
        }else if(!isSuscribed)
        {
            ShakeManager.instance.OnShake += Shake;
            isSuscribed =true;
        }
        
    }

    void Shake()
    {
        transform.DOJump(transform.position, 
        forceJump, jumpQuantity,duration, false).OnComplete(
            ()=>Debug.Log("Termine"));
    }
    void OnDestroy()
    {
        ShakeManager.instance.OnShake -= Shake;
    }
}
