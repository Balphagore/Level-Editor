using UnityEngine;
using System.IO;
public class LevelsLibraryDataSerializer : MonoBehaviour
{
    [SerializeField]
    private string path;
    [SerializeField]
    private LevelsLibraryDataModel levelsLibraryData;
    private void Start()
    {
        Debug.Log("LevelsLibraryDataSerializer Start()");
        path = Path.Combine(Application.persistentDataPath, "LevelsLibraryData.json");
        if (File.Exists(path))
        {
            Debug.Log("File exist");
            LoadLevelsLibrary();
        }
        else
        {
            Debug.Log("File not exist");
            SaveLevelsLibrary();
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
}
