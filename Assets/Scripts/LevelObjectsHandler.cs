using UnityEngine;
using System.Collections.Generic;
public class LevelObjectsHandler : MonoBehaviour
{
    public Transform cameraTransform;
    public Transform lightTransform;
    public GameObject planesContainer;
    public GameObject planePrefab;
    public GameObject terrainsContainer;
    public List<GameObject> terrainPrefabs;
    public GameObject buildingSlotsContainer;
    public GameObject buildingSlotPrefab;
    [SerializeField]
    private LevelDataModel level;
    public LevelDataModel GetLevelObjects()
    {
        Debug.Log("Get Level Objects");
        List<PlaneDataModel> planes = new List<PlaneDataModel>();
        for (int i = 0; i < planesContainer.transform.childCount; i++)
        {
            planes.Add(new PlaneDataModel(planesContainer.transform.GetChild(i).transform.position));
        }
        List<TerrainDataModel> terrains = new List<TerrainDataModel>();
        for (int i = 0; i < terrainsContainer.transform.childCount; i++)
        {
            terrains.Add(new TerrainDataModel(terrainsContainer.transform.GetChild(i).transform.GetComponent<TerrainHandler>().type, terrainsContainer.transform.GetChild(i).transform.position, terrainsContainer.transform.GetChild(i).transform.rotation));
        }
        List<BuildingSlotDataModel> buildingSlots = new List<BuildingSlotDataModel>();
        for (int i = 0; i < buildingSlotsContainer.transform.childCount; i++)
        {
            buildingSlots.Add(new BuildingSlotDataModel(buildingSlotsContainer.transform.GetChild(i).transform.position, buildingSlotsContainer.transform.GetChild(i).transform.rotation));
        }
        level = new LevelDataModel(new TranslationVariantDataModel("---", "---"), new TranslationVariantDataModel("---", "---"), cameraTransform.position, lightTransform.rotation, planes,terrains,buildingSlots,new List<WaveDataModel>());
        return level;
    }
    public void SpawnLevelObjects(LevelDataModel levelData)
    {
        Debug.Log("SpawnLevelObjects()");
        foreach (Transform child in planesContainer.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in terrainsContainer.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in buildingSlotsContainer.transform)
        {
            Destroy(child.gameObject);
        }
        cameraTransform.position = levelData.cameraPosition;
        lightTransform.rotation = levelData.lightRotation;
        for(int i=0;i<levelData.planes.Count;i++)
        {
            Instantiate(planePrefab, levelData.planes[i].position, Quaternion.identity, planesContainer.transform);
        }
        for (int i = 0; i < levelData.terrains.Count; i++)
        {
            Instantiate(terrainPrefabs[levelData.terrains[i].type], levelData.terrains[i].position, levelData.terrains[i].rotation, terrainsContainer.transform);
        }
        for( int i=0; i<levelData.buildingSlots.Count;i++)
        {
            Instantiate(buildingSlotPrefab, levelData.buildingSlots[i].position, levelData.buildingSlots[i].rotation, buildingSlotsContainer.transform);
        }
    }
}
