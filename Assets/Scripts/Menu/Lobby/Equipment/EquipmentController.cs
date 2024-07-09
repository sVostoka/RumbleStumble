using TMPro;
using UnityEngine;
using static Enums;

public class EquipmentController : MonoBehaviour
{
    public void DirectCampaign()
    {
        Conductor.ShowScene(Scenes.Campaign);
    }

    public void DirectShop()
    {
        Conductor.ShowScene(Scenes.Shop);
    }

    public void DirectAptitude()
    {
        Conductor.ShowScene(Scenes.Aptitude);
    }
}
