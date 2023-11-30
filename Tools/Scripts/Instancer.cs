using UnityEngine;

[CreateAssetMenu]
public class Instancer : ScriptableObject
{
    public GameObject prefab, obj;
    public PrefabListSo prefabList;
    private int num = 0;

    public void CreateInstance()
    {
        if (prefab != null)
        {
            Instantiate(prefab);
        }
        else
        {
            Debug.LogWarning("Prefab is null. Unable to instantiate.");
        }
    }

    public void CreateInstance(Vector3Data positionData)
    {
        if (prefab != null && positionData != null)
        {
            Instantiate(prefab, positionData.value, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("Prefab or position data is null. Unable to instantiate.");
        }
    }

    public void CreateInstanceFromList(Vector3DataList positions)
    {
        if (prefab != null && positions != null)
        {
            foreach (var positionData in positions.vector3DList)
            {
                Instantiate(prefab, positionData.value, Quaternion.identity);
            }
        }
        else
        {
            Debug.LogWarning("Prefab or position list is null. Unable to instantiate.");
        }
    }

    public void CreateInstanceFromListCounting(Vector3DataList positions)
    {
        if (prefab != null && positions != null && positions.vector3DList.Count > 0)
        {
            Instantiate(prefab, positions.vector3DList[num].value, Quaternion.identity);
            num++;
            if (num == positions.vector3DList.Count)
            {
                num = 0;
            }
        }
        else
        {
            Debug.LogWarning("Prefab, position list, or position list count is invalid. Unable to instantiate.");
        }
    }

    public void CreateInstanceListRandomly(Vector3DataList positions)
    {
        if (prefab != null && positions != null && positions.vector3DList.Count > 0)
        {
            num = Random.Range(0, positions.vector3DList.Count);
            Instantiate(prefab, positions.vector3DList[num].value, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("Prefab, position list, or position list count is invalid. Unable to instantiate randomly.");
        }
    }

    public void CreateRandomPrefabFromList(Vector3Data positionData)
    {
        Debug.Log("Attempting to create random prefab...");

        if (prefabList != null && prefabList.Prefabs.Length > 0 && positionData != null)
        {
            int randomIndex = Random.Range(0, prefabList.Prefabs.Length);
            GameObject randomPrefab = prefabList.Prefabs[randomIndex];

            if (randomPrefab != null)
            {
                Debug.Log($"Spawn Location: {positionData.value}");
                Instantiate(randomPrefab, positionData.value, Quaternion.identity);
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
