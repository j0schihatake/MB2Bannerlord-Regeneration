//using HarmonyLib;
//using MBOptionScreen.Attributes;
//using MBOptionScreen.Settings;
//using System.Xml.Serialization;

namespace Regeneration
{
    /*
    public class SettingsRus : AttributeSettings<SettingsRus>
    {
        public const string InstanceID = "RegenerationRus";

        public override string Id { get; set; }

        public override string ModuleFolderName => "Regeneration";

        public override string ModName => "Regeneration";

        // Настройки параметров:
        [XmlElement]
        [SettingProperty("Пауза между прибавкой здоровья у персонажа(в сек).", 1, 100, false, "Пауза между прибавкой здоровья у персонажа(в сек).")]
        //[SettingPropertyGroup("Настроечные параметры.")]
        public int RegenerationDelay { get; set; } = 1;
        
        [XmlElement]
        [SettingProperty("Значение прибавки к здоровью персонажа.", 1, 30, false, "Значение на которое будет увеличено здоровье персонажа.")]
        //[SettingPropertyGroup("Настроечные параметры.")]
        public int RegenerationValue { get; set; } = 1;

        // Настройки регенерации игрока:
        [XmlElement]
        [SettingProperty("Категории постепеннной регенерации." , false, "Категории постепенной регенерации.")]
        //[SettingPropertyGroup("Категории постепенной регенерации")]
        public bool CategoryRegeneration { get; set; } = true;

        [XmlElement]
        [SettingProperty("Здоровье всех персонажей.", false, "Постепенная регенерация здоровья всех живых персонажей.")]
        //[SettingPropertyGroup("Категории постепенной регенерации")]
        public bool AllHealthRegeneration { get; set; } = true;

        [XmlElement]
        [SettingProperty("Здоровье игрока.", false, "Постепенная регенерация здоровья игрока.")]
        //[SettingPropertyGroup("Категории постепенной регенерации")]
        public bool PlayerHealthRegeneration { get; set; } = false;

        [XmlElement]
        [SettingProperty("Здоровье напарников игрока.", false, "Регенерация здоровья напарников игрока, включая союзных лордов.")]
        //[SettingPropertyGroup("Категории постепенной регенерации")]
        public bool CompanionHealthRegeneration { get; set; } = false;

        [XmlElement]
        [SettingProperty("Здоровье солдат партии игрока.", false, "Постепенная регенрация здоровья всех солдат партии игрока кроме компаньенов.")]
        //[SettingPropertyGroup("Категории постепенной регенерации")]
        public bool PartyHealthRegeneration { get; set; } = false;

        [XmlElement]
        [SettingProperty("Здоровье вражеских лидеров.", false, "Постепенная регенерация здоровья вражеских лидеров.")]
        //[SettingPropertyGroup("Категории постепенной регенерации")]
        public bool EnemyLeaderHealthRegeneration { get; set; } = false;

        [XmlElement]
        [SettingProperty("Здоровье солдат вражеской партии кроме лордов.", false, "Постепенная регенерация здоровья солдат вражеской партии кроме лордов.")]
        //[SettingPropertyGroup("Категории постепенной регенерации")]
        public bool EnemyPartyHealthRegeneration { get; set; } = false;

        [XmlElement]
        [SettingProperty("Включение/отключение отладочных сообщений.", false, "Включение/отключение отладочных сообщений.")]
        //[SettingPropertyGroup("Режим разработки")]
        public bool EnableMessage { get; set; } = false;
    }
    */
}
