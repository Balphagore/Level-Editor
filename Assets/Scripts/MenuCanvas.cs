using UnityEngine;
public class MenuCanvas : MonoBehaviour
{
    public LevelsLibraryDataSerializer levelsLibraryDataSerializer;
    public void OnUpdateLevelsLibraryButtonClick()
    {
        Debug.Log("OnUpdateLevelsLibraryButtonClick()");
        levelsLibraryDataSerializer.UpdateLevelsLibrary();
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
}
