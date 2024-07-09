using UnityEngine;
using static Enums;

public class AptitudeMenuController : MonoBehaviour
{
    public void DirectCampaign()
    {
        Conductor.ShowScene(Scenes.Campaign);
    }

    public void DirectEquipment()
    {
        Conductor.ShowScene(Scenes.Equipment);
    }

    public void DirectShop()
    {
        Conductor.ShowScene(Scenes.Shop);
    }
}