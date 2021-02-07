using UnityEngine;
using System.Collections.Generic;
public class LevelObjectsHandler : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private Transform lightTransform;
    [SerializeField] private GameObject planesContainer;
    [SerializeField] private GameObject planePrefab;
    [SerializeField] private GameObject terrainsContainer;
    [SerializeField] private List<GameObject> terrainPrefabs;
    [SerializeField] private GameObject buildingSlotsContainer;
    [SerializeField] private GameObject buildingSlotPrefab;
    [SerializeField] private GameObject pathVariantsContainer;
    [SerializeField] private GameObject pathVariantPrefab;
    [SerializeField] private GameObject wayPointPrefab;
    [SerializeField] private LevelDataModel level;
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
    public List<PathVariantDataModel> GetPathVariants()
    {
        List<PathVariantDataModel> pathVariants = new List<PathVariantDataModel>();
        for (int i = 0; i < pathVariantsContainer.transform.childCount; i++)
        {
            List<WayPointDataModel> wayPoints = new List<WayPointDataModel>();
            for (int j = 1; j < pathVariantsContainer.transform.GetChild(i).transform.childCount-1; j++)
            {
                wayPoints.Add(new WayPointDataModel(pathVariantsContainer.transform.GetChild(i).transform.GetChild(j).transform.position));
            }
            pathVariants.Add(new PathVariantDataModel(pathVariantsContainer.transform.GetChild(i).transform.GetChild(0).transform.position, pathVariantsContainer.transform.GetChild(i).transform.GetChild(0).transform.rotation, wayPoints, pathVariantsContainer.transform.GetChild(i).transform.GetChild(pathVariantsContainer.transform.GetChild(i).transform.childCount-1).transform.position, pathVariantsContainer.transform.GetChild(i).transform.GetChild(pathVariantsContainer.transform.GetChild(i).transform.childCount - 1).transform.rotation));
        }
        return pathVariants;
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
        for(int i=0;i< levelData.pathVariants.Count;i++)
        {
            GameObject prefab=Instantiate(pathVariantPrefab, pathVariantsContainer.transform);
            Instantiate(wayPointPrefab, levelData.pathVariants[i].spawnPointPosition, levelData.pathVariants[i].spawnPointRotation, prefab.transform);
            for(int j=0;j<levelData.pathVariants[i].wayPoints.Count;j++)
            {
                Instantiate(wayPointPrefab, levelData.pathVariants[i].wayPoints[j].wayPointPosition, Quaternion.identity,prefab.transform);
            }
            Instantiate(wayPointPrefab, levelData.pathVariants[i].endPointPosition, levelData.pathVariants[i].endPointRotation, prefab.transform);
        }
    }
}
