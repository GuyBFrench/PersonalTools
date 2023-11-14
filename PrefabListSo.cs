using UnityEngine;

[CreateAssetMenu(fileName = "PrefabList", menuName = "ScriptableObjects/PrefabList", order = 1)]
public class PrefabListSo : ScriptableObject
{
    [SerializeField]
    private GameObject[] prefabs;

    public GameObject[] Prefabs
    {
        get { return prefabs; }
    }
}