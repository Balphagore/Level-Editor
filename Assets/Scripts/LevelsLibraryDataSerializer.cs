using UnityEngine;
using System.IO;
using System.Collections.Generic;
public class LevelsLibraryDataSerializer : MonoBehaviour
{
    [SerializeField]
    private string path;
    [SerializeField]
    private int currentCampaingNumber;
    [SerializeField]
    private int currentLevelNumber;
    [SerializeField]
    private LevelsLibraryDataModel levelsLibraryData;
    public LevelObjectsHandler levelObjectsHandler;
    private void Start()
    {
        Debug.Log("LevelsLibraryDataSerializer Start()");
        //path = Path.Combine(Application.persistentDataPath, "LevelsLibraryData.json");
        path = Path.Combine(Application.dataPath + "/Resources", "LevelsLibraryData.json");
        if (File.Exists(path))
        {
            Debug.Log("File exist");
            LoadLevelsLibrary();
        }
        else
        {
            Debug.Log("File not exist");
            ResetLevelsLibrary();
        }
    }
    public void SaveLevelsLibrary()
    {
        Debug.Log("Save levels library");
        File.WriteAllText(path, JsonUtility.ToJson(levelsLibraryData));
    }
    public void LoadLevelsLibrary()
    {
        Debug.Log("Load levels library");
        levelsLibraryData = JsonUtility.FromJson<LevelsLibraryDataModel>(File.ReadAllText(path));
    }
    public void ResetLevelsLibrary()
    {
        Debug.Log("Reset levels library");
        levelsLibraryData = new LevelsLibraryDataModel(new System.Collections.Generic.List<CampaingDataModel>());
        SaveLevelsLibrary();
    }
    public void LoadLevel()
    {
        Debug.Log("Load level");
        if (currentCampaingNumber > 0)
        {
            if (currentCampaingNumber > levelsLibraryData.campaings.Count)
            {
                Debug.Log("Campaing not found!");
            }
            else
            {
                if (currentLevelNumber > 0)
                {
                    if (currentLevelNumber > levelsLibraryData.campaings[currentCampaingNumber - 1].levels.Count)
                    {
                        Debug.Log("Level not found!");
                    }
                    else
                    {
                        levelObjectsHandler.SpawnLevelObjects(levelsLibraryData.campaings[currentCampaingNumber - 1].levels[currentLevelNumber - 1]);
                    }
                }
                else
                {
                    Debug.Log("Level number not choosen!");
                }
            }
        }
        else
        {
            Debug.Log("Campaing number not choosen!");
        }
    }
    public void SaveLevel()
    {
        Debug.Log("Save level");
        Debug.Log(levelObjectsHandler.GetLevelObjects().cameraPosition);
        levelsLibraryData.campaings[currentCampaingNumber-1].levels[currentLevelNumber-1] = levelObjectsHandler.GetLevelObjects();
        SaveLevelsLibrary();
    }
    public void AddLevel()
    {
        Debug.Log("Add level");
        TranslationVariantDataModel translationVariant = new TranslationVariantDataModel("---", "---");
        List<PlaneDataModel> planesData = new List<PlaneDataModel>();
        List<TerrainDataModel> terrainsData = new List<TerrainDataModel>();
        List<BuildingSlotDataModel> buildingSlotsData = new List<BuildingSlotDataModel>();
        List<WaveDataModel> wavesData = new List<WaveDataModel>();
        if (currentCampaingNumber > 0)
        {
            levelsLibraryData.campaings[currentCampaingNumber - 1].levels.Add(new LevelDataModel(translationVariant, translationVariant, Vector3.zero, Quaternion.identity, planesData, terrainsData, buildingSlotsData, wavesData));
        }
        else
        {
            Debug.Log("Campaing number not choosen!");
        }
    }
    public void AddCampaing()
    {
        Debug.Log("Add campaing");
        List<LevelDataModel> levelsData = new List<LevelDataModel>();
        TranslationVariantDataModel translationVariant = new TranslationVariantDataModel("---", "---");
        levelsLibraryData.campaings.Add(new CampaingDataModel(translationVariant, translationVariant, levelsData));
    }
}
