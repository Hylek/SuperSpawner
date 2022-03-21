using UnityEngine;

public class AlliedSpawner : MonoBehaviour
{
    private ICopyable _copy;

    public Unit SpawnAlly(Unit prototype)
    {
        _copy = prototype.Copy();

        return (Unit) _copy;
    }
}