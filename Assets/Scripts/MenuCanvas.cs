using UnityEngine;
public class MenuCanvas : MonoBehaviour
{
    public LevelsLibraryDataSerializer levelsLibraryDataSerializer;
    public void OnSaveLevelsLibraryButtonClick()
    {
        Debug.Log("OnSaveLevelsLibraryButtonClick()");
        levelsLibraryDataSerializer.SaveLevelsLibrary();
    }
}
