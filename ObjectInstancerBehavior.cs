using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInstancerBehavior : MonoBehaviour
{
    public PrefabListSo prefabList;
    public GameObject obj;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void CreateRandomPrefabFromList()
    {
        Debug.Log("Attempting to create random prefab...");

        if (prefabList != null && prefabList.Prefabs.Length > 0)
        {
            int randomIndex = Random.Range(0, prefabList.Prefabs.Length);
            GameObject randomPrefab = prefabList.Prefabs[randomIndex];

            if (randomPrefab != null)
            {
                //Debug.Log($"Spawn Location: {positionData.value}");
                Instantiate(randomPrefab, obj.transform.position, Quaternion.identity);
                Debug.Log("Prefab instantiated successfully.");
            }
            else
            {
                Debug.LogWarning("Random prefab is null. Unable to instantiate.");
            }
        }
        else
        {
            Debug.LogWarning("Prefab list, prefab count, or position data is invalid. Unable to instantiate random prefab from the list.");
        }
    }
}
