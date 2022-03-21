using UnityEngine;

namespace PrototypePattern
{
    public class Unit : MonoBehaviour, ICopyable
    {
        public Vector3 startPosition;
    
        public ICopyable Copy() => Instantiate(this);
    
        public virtual void Activate()
        {
        
        }

        public virtual void DeActivate()
        {
            GameObject o;
            (o = gameObject).SetActive(false);
            o.transform.position = startPosition;
        }
    }
}