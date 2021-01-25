using UnityEngine;
using System.Collections.Generic;
public class LevelObjectsHandler : MonoBehaviour
{
    public Transform cameraTransform;
    public Transform lightTransform;
    public GameObject planesContainer;
    public GameObject terrainsContainer;
    public GameObject buildingSlotsContainer;
    [SerializeField]
    private LevelDataModel level;
    public void GetLevelObjects()
    {
        Debug.Log("Get Level Objects");
        List<PlaneDataModel> planes = new List<PlaneDataModel>();
        for (int i = 0; i < planesContainer.transform.childCount; i++)
        {
            planes.Add(new PlaneDataModel(i, planesContainer.transform.GetChild(i).transform.position));
        }
        List<TerrainDataModel> terrains = new List<TerrainDataModel>();
        for (int i = 0; i < terrainsContainer.transform.childCount; i++)
        {
            terrains.Add(new TerrainDataModel(i, terrainsContainer.transform.GetChild(i).transform.GetComponent<TerrainHandler>().type, terrainsContainer.transform.GetChild(i).transform.position, terrainsContainer.transform.GetChild(i).transform.rotation));
        }
        List<BuildingSlotDataModel> buildingSlots = new List<BuildingSlotDataModel>();
        for (int i = 0; i < buildingSlotsContainer.transform.childCount; i++)
        {
            buildingSlots.Add(new BuildingSlotDataModel(i, buildingSlotsContainer.transform.GetChild(i).transform.position, buildingSlotsContainer.transform.GetChild(i).transform.rotation));
        }
        level = new LevelDataModel(0, new TranslationVariantDataModel("---", "---"), new TranslationVariantDataModel("---", "---"), cameraTransform.position, lightTransform.rotation, planes,terrains,buildingSlots,new List<WaveDataModel>());
    }
}
