//using HarmonyLib;
//using MBOptionScreen.Attributes;
//using MBOptionScreen.Settings;
//using System.Collections.Generic;
//using System.Xml.Serialization;

namespace Regeneration
{
    /*
    public class SettingsEng : SettingsBase
    {
        public const string InstanceID = "RegenerationByJ0schiSettingsEng";

        public override string ModName => "Regeneration";

        public override string ModuleFolderName => "Regeneration";

        [XmlElement]
        public override string Id { get; set; } = "RegenerationByJ0schiSettingsEng";

        public static SettingsEng Instance
        {
            get {
                if(SettingsEng.Instance == null) {
                    new Harmony("Name.Regeneration").PatchAll();
                }
                return SettingsBase<SettingsEng>.Instance;
            }
        }

        // Настройки параметров:
        [XmlElement]
        [SettingProperty("Pause between the character’s health gain (in sec).", 1, 100, false, "Pause between the character’s health gain (in sec).")]
        [SettingPropertyGroup("Tuning parameters.", false)]
        public int RegenerationDelay { get; set; } = 1;
        
        [XmlElement]
        [SettingProperty("The value of the character’s health gain.", 1, 30, false, "The value by which the character's health will be increased.")]
        [SettingPropertyGroup("Tuning parameters.", false)]
        public int RegenerationValue { get; set; } = 1;

        // Настройки регенерации игрока:
        [XmlElement]
        [SettingProperty("Categories of gradual regeneration.", false, "Categories of gradual regeneration.")]
        [SettingPropertyGroup("Gradual Regeneration Categories", true)]
        public bool CategoryRegeneration { get; set; } = true;

        [XmlElement]
        [SettingProperty("The health of all characters.", false, "Gradual health regeneration of all living characters.")]
        [SettingPropertyGroup("Gradual Regeneration Categories", false)]
        public bool AllHealthRegeneration { get; set; } = true;

        [XmlElement]
        [SettingProperty("Player Health", false, "Gradual regeneration of player’s health.")]
        [SettingPropertyGroup("Gradual Regeneration Categories", false)]
        public bool PlayerHealthRegeneration { get; set; } = false;

        [XmlElement]
        [SettingProperty("Player mates health.", false, "Regeneration of the player’s teammates health, including Allied Lords.")]
        [SettingPropertyGroup("Gradual Regeneration Categories", false)]
        public bool CompanionHealthRegeneration { get; set; } = false;

        [XmlElement]
        [SettingProperty("Health soldier party player.", false, "Gradual health regeneration of all soldiers of the player party except companions.")]
        [SettingPropertyGroup("Gradual Regeneration Categories", false)]
        public bool PartyHealthRegeneration { get; set; } = false;

        [XmlElement]
        [SettingProperty("The health of enemy leaders.", false, "Gradual health regeneration of enemy leaders.")]
        [SettingPropertyGroup("Gradual Regeneration Categories", false)]
        public bool EnemyLeaderHealthRegeneration { get; set; } = false;

        [XmlElement]
        [SettingProperty("Health of soldiers of an enemy party other than Lords.", false, "Gradual regeneration of the health of soldiers of an enemy party except for Lords.")]
        [SettingPropertyGroup("Gradual Regeneration Categories", false)]
        public bool EnemyPartyHealthRegeneration { get; set; } = false;

        [XmlElement]
        [SettingProperty("Enable / disable debugging messages.", false, "Enable / disable debugging messages.")]
        [SettingPropertyGroup("Development mode", false)]
        public bool EnableMessage { get; set; } = false;
    }
    */
}
