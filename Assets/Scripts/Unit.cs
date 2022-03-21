using UnityEngine;

public class Unit : MonoBehaviour, ICopyable
{
    public ICopyable Copy() => Instantiate(this);
    public virtual void Activate()
    {
        
    }
}