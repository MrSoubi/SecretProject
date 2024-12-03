using UnityEngine;

[CreateAssetMenu(fileName = "MapsInfos", menuName = "Maps Infos")]
public class MapsInfos : ScriptableObject
{
    [HideInInspector] private GameObject map;
    [SerializeField] private Bounds boxCollider;

    public GameObject Map
    {
        get => map;
        set => map = value;
    }

    public Bounds Bounds
    {
        get => boxCollider;
        set => boxCollider = value;
    }
}
