using UnityEngine;
public class MenuCanvas : MonoBehaviour
{
    public LevelsLibraryDataSerializer levelsLibraryDataSerializer;
    public void OnSaveLevelButtonClick()
    {
        Debug.Log("OnSaveLevelButtonClick()");
        levelsLibraryDataSerializer.SaveLevel();
    }
    public void OnSaveLevelsLibraryButtonClick()
    {
        Debug.Log("OnSaveLevelsLibraryButtonClick()");
        levelsLibraryDataSerializer.SaveLevelsLibrary();
    }
    public void OnResetLevelsLibraryButtonClick()
    {
        Debug.Log("OnResetLevelsLibraryButtonClick()");
        levelsLibraryDataSerializer.ResetLevelsLibrary();
    }
    public void OnLoadLevelButtonClick()
    {
        Debug.Log("OnLoadLevelButtonClick()");
        levelsLibraryDataSerializer.LoadLevel();
    }
}
