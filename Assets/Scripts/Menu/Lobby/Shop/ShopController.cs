using UnityEngine;
using static Enums;

public class ShopController : MonoBehaviour
{
    public void DirectCampaign()
    {
        Conductor.ShowScene(Scenes.Campaign);
    }

    public void DirectEquipment()
    {
        Conductor.ShowScene(Scenes.Equipment);
    }

    public void DirectAptitude()
    {
        Conductor.ShowScene(Scenes.Aptitude);
    }
}