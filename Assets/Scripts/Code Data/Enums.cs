public static class Enums
{
    public enum Axis
    {
        Horizontal,
        Vertical,
    }

    public enum Side
    {
        Top,
        Bottom,
        Left,
        Right,
    }

    public enum Scenes
    {
        MainMenu = 0,
        Campaign = 1,
        Equipment = 2,
        Shop = 3,
        Aptitude = 4,
        Settings = 5,
        Authors = 6,
        Game = 7,
    }

    public enum SocialMedia
    {
        VK,
        Telegram,
        YouTube,
        Discord,
    }

    public enum TypeSettings
    {
        General,
        Control,
        Graphic,
        Sound,
    }

    public enum TypeGeneralSettings
    {
        Sensitivity,
        Acceleration,
        Squat,
        InvetY,
    }

    public enum Complexity
    {
        Intern,
        Experienced,
        Seasoned,
        Nightmare,
    }

    public enum TypeItem
    {
        Weapon,
        Armor,
        Amulet,
        Bracelet,
        Ring,
    }

    public enum Rarity
    {
        Standard,
        Rare,
        Unusual,
        Epic,
        Legendary,
    }

    public enum TypeSortItems
    {
        ByLevel,
        ByRariry,
        ByTypeItem
    }

    public enum TypeSizeProps
    {
        Small,
        Medium,
        Large,
    }

    public enum AttackPattern
    {
        DamageArea,
        DashForward,
        Explosion,
        Clot,
        Burst,
        Attraction
    }

    public enum TypeSlot
    {
        Outfit,
        Sale,
        Inventory
    }

    public enum HeroStance
    {
        Stand,
        Crouch
    }
}
