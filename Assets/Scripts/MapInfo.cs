using UnityEngine;

public class MapInfo : MonoBehaviour
{
    [Header("ScriptableObject")]
    [SerializeField] private MapsInfos mapInfos;

    void Start()
    {
        mapInfos.Map = transform.parent.gameObject;
        mapInfos.Bounds = GetComponent<BoxCollider>().bounds;
    }
}
