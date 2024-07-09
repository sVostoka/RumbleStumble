using static Enums;

public static class Constants
{
    public static class Bank
    {
        public const string PREFSKEY = "Bank";
        public const string PREFSDEFAULTVALUE = "";

        public const int COINSDEFAULTVALUE = 0;
        public const int DIAMONDSDEFAULTVALUE = 0;
    }

    public static class Level
    {
        public const string PREFSKEY = "Level";
        public const string PREFSDEFAULTVALUE = "";

        public const int VALUEDEFAULTVALUE = 0;
        public const int EXPERIENCEDEFAULTVALUE = 0;
    }


    #region Equipment

    public static class UnitsLabel
    {
        public const string UNIT = "וה";
        public const string METER = "ל";
        public const string PIECE = "רע";
        public const string SECOND = "סוך";
        public const string PERCENT = "%";
    }

    public static class Weapon
    {
        public const string PREFSKEY = "Weapon";
        public const string PREFSDEFAULTVALUE = "";

        public const string MODELSRCDEFAULTVALUE = "Models/Weapons/m4a1";
        public const string IMAGESRCDEFAULTVALUE = "Image/Menu/Logo 500x470";
        public const Rarity RARITYDEFAULTVALUE = Rarity.Standard;
        public const int PRICESELLDEFAULTVALUE = 100;
        public const int PRICEBUYDEFAULTVALUE = 50;
        public const int PRICEUPDEFAULTVALUE = 10;
        public const int LEVELDEFAULTVALUE = 1;
        public const int DAMAGEDEFAULTVALUE = 10;
        public const int RANGEDEFAULTVALUE = 100;
        public const int AMMOCOUNTDEFAULTVALUE = 30;
        public const float RELOADINGDEFAULTVALUE = 2.0f;

        public const string DAMAGELABELSRC = "Image/Menu/Lobby/Equipment/About Item/Weapon/Equipment About Item Weapon Damage";
        public const string RANGELABELSRC = "Image/Menu/Lobby/Equipment/About Item/Weapon/Equipment About Item Weapon Range";
        public const string AMMOCOUNTLABELSRC = "Image/Menu/Lobby/Equipment/About Item/Weapon/Equipment About Item Weapon Ammo Count";
        public const string RELOADINGLABELSRC = "Image/Menu/Lobby/Equipment/About Item/Weapon/Equipment About Item Weapon Reloading";
    }

    public static class Armor
    {
        public const string PREFSKEY = "Armor";
        public const string PREFSDEFAULTVALUE = "";

        public const string STRENGTHLABELSRC = "Image/Menu/Lobby/Equipment/About Item/Armor/Equipment About Item Armor Strength";
        public const string RESISTLABELSRC = "Image/Menu/Lobby/Equipment/About Item/Armor/Equipment About Item Armor Resist";
    }

    public static class Amulet
    {
        public const string PREFSKEY = "Amulet";
        public const string PREFSDEFAULTVALUE = "";

        public const string HPBOOSTLABELSRC = "Image/Menu/Lobby/Equipment/About Item/Amulet/Equipment About Item Amulet HP Boost";
    }

    public static class Bracelet
    {
        public const string PREFSKEY = "Bracelet";
        public const string PREFSDEFAULTVALUE = "";

        public const string DAMAGEBOOSTLABELSRC = "Image/Menu/Lobby/Equipment/About Item/Bracelet/Equipment About Item Bracelet Damage";
    }

    public static class Ring
    {
        public const string PREFSKEY = "Ring";
        public const string PREFSKEYLEFT = "RingLeft";
        public const string PREFSKEYRIGHT = "RingRight";
        public const string PREFSDEFAULTVALUE = "";

        public const string SPEEDBOOST = "Image/Menu/Lobby/Equipment/About Item/Ring/Equipment About Item Ring Speed";
    }

    public static class RaritySrc
    {
        public const string STANDARTBACKGROUNDSRC = "Image/Menu/Lobby/Item Background Standard";
        public const string RAREBACKGROUNDSRC = "Image/Menu/Lobby/Item Background Rare";
        public const string UNUSUALBACKGROUNDSRC = "Image/Menu/Lobby/Item Background Unusual";
        public const string EPICBACKGROUNDSRC = "Image/Menu/Lobby/Item Background Epic";
        public const string LEGENDARYBACKGROUNDSRC = "Image/Menu/Lobby/Item Background Legendary";

        public const string STANDARTLABELSRC = "Image/Menu/Lobby/Equipment/About Item/Equipment About Item Quality Standard";
        public const string RARELABELSRC = "Image/Menu/Lobby/Equipment/About Item/Equipment About Item Quality Rare";
        public const string UNUSUALLABELSRC = "Image/Menu/Lobby/Equipment/About Item/Equipment About Item Quality Unusual";
        public const string EPICLABELSRC = "Image/Menu/Lobby/Equipment/About Item/Equipment About Item Quality Epic";
        public const string LEGENDARYLABELSRC = "Image/Menu/Lobby/Equipment/About Item/Equipment About Item Quality Legendary";
    }

    public static class AboutElementController
    {
        public const float PADDINGPARAMS = 80.0f;
    }

    #endregion

    #region Talents

    public static class Health
    {
        public const string PREFSKEY = "Health";
        public const string PREFSDEFAULTVALUE = "";

        public const int LEVELDEFAULTVALUE = 0;
        public const int HPBOOSTDEFAULTVALUE = 0;
    }

    public static class Speed
    {
        public const string PREFSKEY = "Speed";
        public const string PREFSDEFAULTVALUE = "";

        public const int LEVELDEFAULTVALUE = 0;
        public const int SPEEDBOOSTDEFAULTVALUE = 0;
    }

    public static class Bounce
    {
        public const string PREFSKEY = "Bounce";
        public const string PREFSDEFAULTVALUE = "";

        public const int LEVELDEFAULTVALUE = 0;
        public const int BOUNCEBOOSTDEFAULTVALUE = 0;
    }

    public static class Stability
    {
        public const string PREFSKEY = "Stability";
        public const string PREFSDEFAULTVALUE = "";

        public const int LEVELDEFAULTVALUE = 0;
        public const int RESISTBOOSTDEFAULTVALUE = 0;
    }

    public static class Power
    {
        public const string PREFSKEY = "Power";
        public const string PREFSDEFAULTVALUE = "";

        public const int LEVELDEFAULTVALUE = 0;
        public const int DAMAGEBOOSTDEFAULTVALUE = 0;
    }

    public static class Treatment
    {
        public const string PREFSKEY = "Treatment";
        public const string PREFSDEFAULTVALUE = "";

        public const int LEVELDEFAULTVALUE = 0;
        public const int TREATMENTBOOSTDEFAULTVALUE = 0;
    }

    public static class Block
    {
        public const string PREFSKEY = "Block";
        public const string PREFSDEFAULTVALUE = "";

        public const int LEVELDEFAULTVALUE = 0;
        public const int BLOCKCHANCEDEFAULTVALUE = 0;
    }

    public static class RechargeSpeed
    {
        public const string PREFSKEY = "RechargeSpeed";
        public const string PREFSDEFAULTVALUE = "";

        public const int LEVELDEFAULTVALUE = 0;
        public const int RECHARGESPEEDBOOSTDEFAULTVALUE = 0;
    }

    public static class Leadership
    {
        public const string PREFSKEY = "Leadership";
        public const string PREFSDEFAULTVALUE = "";

        public const int LEVELDEFAULTVALUE = 0;
        public const int HEALTHLEVELUPDEFAULTVALUE = 0;
    }

    public static class Glory
    {
        public const string PREFSKEY = "Glory";
        public const string PREFSDEFAULTVALUE = "";

        public const int LEVELDEFAULTVALUE = 0;
        public const int COUNTEXTRASKILLSDEFAULTVALUE = 0;
    }

    public static class Income
    {
        public const string PREFSKEY = "Income";
        public const string PREFSDEFAULTVALUE = "";

        public const int LEVELDEFAULTVALUE = 0;
        public const int INCOMEBOOSTDEFAULTVALUE = 0;
    }

    public static class Loss
    {
        public const string PREFSKEY = "Loss";
        public const string PREFSDEFAULTVALUE = "";

        public const int LEVELDEFAULTVALUE = 0;
        public const int SAVEONLOSSDEFAULTVALUE = 0;
    }

    #endregion

    #region Inventory
    
    public static class Inventory
    {
        public const string PREFSKEY = "Inventory";
        public const string PREFSDEFAULTVALUE = "";
    }

    #endregion

    #region Shop

    public static class SaleItems
    {
        public const string PREFSKEY = "SaleItems";
        public const string PREFSDEFAULTVALUE = "";
    }

    public static class SaleBoxes
    {
        public const string PREFSKEY = "SaleBoxes";
        public const string PREFSDEFAULTVALUE = "";
    }

    public static class AboutBoxController
    {
        public const string WEAPONBOXLABEL = "Image/Menu/Lobby/Shop/Shop Weapon Box Label";
        public const string ARMORBOXLABEL = "Image/Menu/Lobby/Shop/Shop Armor Box Label";
        public const string AMULETBOXLABEL = "Image/Menu/Lobby/Shop/Shop Amulets Box Label";
        public const string BRACELETBOXLABEL = "Image/Menu/Lobby/Shop/Shop Bracelets Box Label";
        public const string RINGBOXLABEL = "Image/Menu/Lobby/Shop/Shop Ring Box Label";
    }

    #endregion

    #region Settings

    public static class GeneralSettings
    {
        public const string PREFSKEY = "GeneralSettings";
        public const string PREFSDEFAULTVALUE = "";

        public const float GENERALDEFAULTSENSITIVITY = 0.5f;
        public const int GENERALDEFAULTACCELERATION = 0;
        public const int GENERALDEFAULTSQUAT = 0;
        public const int GENERALDEFAULTINVERTY = 0;
    }

    public static class ControlSettings
    {
        public const string PREFSKEY = "ControlSettings";
        public const string PREFSDEFAULTVALUE = "";

        public const string STUBDEFAULTTEST = "stub";
    }

    public static class GraphicSettings
    {
        public const string PREFSKEY = "GraphicSettings";
        public const string PREFSDEFAULTVALUE = "";

        public const float GRAPHICDEFAULTBRIGHTNESS = 0.5f;
        public const int GRAPHICDEFAULTRESOLUTION = 0;
        public const int GRAPHICDEFAULTMODE = 0;

        public const int GRAPHICDEFAULTTEXTURES = 0;
        public const int GRAPHICDEFAULTSHADOWS = 0;
        public const int GRAPHICDEFAULTEFFECTS = 0;
        public const int GRAPHICDEFAULTLIGHTING = 0;
    }

    public static class SoundSettings
    {
        public const string PREFSKEY = "SoundSettings";
        public const string PREFSDEFAULTVALUE = "";

        public const float SOUNDOVERALLVOLUME = 0.5f;
        public const float SOUNDEFFECTSVOLUME = 0.5f;
        public const float SOUNDMUSICVOLUME = 0.5f;
        public const float SOUNDINTERFACEVOLUME = 0.5f;
        public const float SOUNDAMBIENTVOLUME = 0.5f;
    }

    public static class SettingsGeneralController
    {
        public const string VALUEPRESSLABEL = "Image/Menu/Settings/General/Settings General Switch Value Label Press";
        public const string VALUEHOLDLABEL = "Image/Menu/Settings/General/Settings General Switch Value Label Hold";

        public const string VALUEYESLABEL = "Image/Menu/Settings/General/Settings General Switch Value Label Yes";
        public const string VALUENOLABEL = "Image/Menu/Settings/General/Settings General Switch Value Label No";
    }

    public static class SettingsGraphicController
    {
        public const string VALUERESOLUTION720LABEL = "Image/Menu/Settings/Graphic/Settings Graphic Switch Value Label Resolution 720";
        public const string VALUERESOLUTION1080LABEL = "Image/Menu/Settings/Graphic/Settings Graphic Switch Value Label Resolution 1080";

        public const string VALUEMODEWINDOWLABEL = "Image/Menu/Settings/Graphic/Settings Graphic Switch Value Label Window";
        public const string VALUEMODEFULLSCREENLABEL = "Image/Menu/Settings/Graphic/Settings Graphic Switch Value Label Full Screen";

        public const string VALUELOWLABEL = "Image/Menu/Settings/Graphic/Settings Graphic Switch Value Label Low";
        public const string VALUEMIDDLELABEL = "Image/Menu/Settings/Graphic/Settings Graphic Switch Value Label Middle";
        public const string VALUEHIGHLABEL = "Image/Menu/Settings/Graphic/Settings Graphic Switch Value Label High";
    }

    #endregion

    public static class MainMenu
    {
        public const string CONTINUEBUTTON = "Continue";
    }

    #region Generation

    public static class RoomGenerator
    {
        public const int PRELOADCOUNT = 3;
        public const float OFFSETWALL = 1.5f;
        public const float DISTANCEDOOR = 15f;

        public const string LEFTWALL = "Main Wall Left";
        public const string RIGHTWALL = "Main Wall Right";
        public const string BACKWALL = "Main Wall Back";
        public const string FRONTWALL = "Main Wall Front";

        public const string DOORUNION = "Door Walls";

        public const string DOORNEXTROOM = "Door In Next Room";
        public const string LEFTDOORWALL = "Left Door Wall";
        public const string RIGHTDOORWALL = "Right Door Wall";
    }

    public static class TerrainGenerator
    {
        public const float ROUGHNESS = 0.032f;
        public const int GRAINCOEFF = 25;

        public const int HEIGHT = 170;
        public const int WIDTH = 120;
    }

    public static class EnvironmentGenerator
    {
        public const int PRELOADTILECOUNT = 3;
        public const int PRELOADPROPSCOUNT = 5;
        public const float SIZETILE = 14.0f;
    }

    public static class EnemiesGenerator
    {
        public const int PRELOADENEMYCOUNT = 3;
    }

    public static class PropController
    {
        public const float PROBABILITYSPAWNPROP = 0.5f;
    }

    #endregion

    public static class CampaignController
    {
        public const string VALUEINTERNACTIVE = "Image/Menu/Lobby/Campaign/Campaign Complexity Intern Active Button";
        public const string VALUEINTERNINACTIVE = "Image/Menu/Lobby/Campaign/Campaign Complexity Intern Button";

        public const string VALUEEXPERIENCEDACTIVE = "Image/Menu/Lobby/Campaign/Campaign Complexity Experienced Active Button";
        public const string VALUEEXPERIENCEDINACTIVE = "Image/Menu/Lobby/Campaign/Campaign Complexity Experienced Button";

        public const string VALUESEASONEDACTIVE = "Image/Menu/Lobby/Campaign/Campaign Complexity Seasonde Active Button";
        public const string VALUESEASONEDINACTIVE = "Image/Menu/Lobby/Campaign/Campaign Complexity Seasonde Button";

        public const string VALUENIGHTMAREACTIVE = "Image/Menu/Lobby/Campaign/Campaign Complexity Nightmare Active Button";
        public const string VALUENIGHTMAREINACTIVE = "Image/Menu/Lobby/Campaign/Campaign Complexity Nightmare Button";
    }
}
