using System;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;
using System.Collections.Generic;
using System.Linq;
using TaleWorlds.Library;
using System.IO;
using System.Reflection;

namespace Regeneration
{
    public class Regeneration : MBSubModuleBase
    {
        private Agent playerAgent;

        // Настроечные параметры:
        private float regenerationValue;
        private float regenerationDelay;
        private bool allHealthRegeneration;
        private bool playerHealthRegeneration;
        private bool companionHealthRegeneration;
        private bool partyHealthRegeneration;
        private bool enemyLeaderHealthRegeneration;
        private bool enemyPartyHealthRegeneration;

        private bool enableMessage = false;
        private int allUnitCount = 0;

        private int startTime = 1;
        private List<Agent> targetAgentList;

        
        protected override void OnBeforeInitialModuleScreenSetAsRoot()
        {

            try
            {
                string[] strArray = File.ReadAllLines(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "/RegenConfig.cfg");
                this.regenerationDelay = float.Parse(strArray[0].Split('#')[1].Trim());
                this.regenerationValue = float.Parse(strArray[1].Split('#')[1].Trim());
                this.allHealthRegeneration = (int.Parse(strArray[2].Split('#')[1].Trim())) == 1 ? true : false;
                this.playerHealthRegeneration = (int.Parse(strArray[3].Split('#')[1].Trim())) == 1 ? true : false;
                this.companionHealthRegeneration = (float.Parse(strArray[4].Split('#')[1].Trim())) == 1 ? true : false;
                this.partyHealthRegeneration = (float.Parse(strArray[5].Split('#')[1].Trim())) == 1 ? true : false;
                this.enemyLeaderHealthRegeneration = (float.Parse(strArray[6].Split('#')[1].Trim())) == 1 ? true : false;
                this.enemyPartyHealthRegeneration = (float.Parse(strArray[7].Split('#')[1].Trim())) == 1 ? true : false;
            }
            catch(FileNotFoundException ex)
            {
                InformationManager.DisplayMessage(new InformationMessage("Config not found, using default values"));
                this.regenerationDelay = 2;
                this.regenerationValue = 0.5f;
                this.allHealthRegeneration = false;
                this.playerHealthRegeneration = true;
                this.companionHealthRegeneration = true;
                this.partyHealthRegeneration = false;
                this.enemyLeaderHealthRegeneration = true;
                this.enemyPartyHealthRegeneration = false;
            }

            InformationManager.DisplayMessage(new InformationMessage("Regeneration mod loaded."));
        }

        protected override void OnSubModuleLoad()
        {
            base.OnSubModuleLoad();
            /*
            try{
                new Harmony("Name.Regeneration").PatchAll();

                if(russian) {

                    SettingsRus Instance = SettingsBase<SettingsRus>.Instance;

                    this.regenerationDelay = Instance.RegenerationDelay;
                    this.regenerationValue = Instance.RegenerationValue;
                    this.allHealthRegeneration = Instance.AllHealthRegeneration;
                    this.playerHealthRegeneration = Instance.PlayerHealthRegeneration;
                    this.companionHealthRegeneration = Instance.CompanionHealthRegeneration;
                    this.partyHealthRegeneration = Instance.PartyHealthRegeneration;
                    this.enemyLeaderHealthRegeneration = Instance.EnemyLeaderHealthRegeneration;
                    this.enemyPartyHealthRegeneration = Instance.EnemyPartyHealthRegeneration;
                }
            }
            catch(Exception ex)
            {
                int num = (int)MessageBox.Show(string.Format("{0} error: failed to apply Harmony patch.\n\n{1}", (object)"Regeneration", (object)ex));
            }
            /*
            
            try
            {
                // Настройка воможности конфигурирования через мод.
                /FileDatabase.Initialise(Regeneration.ModuleFolderName);
                
                //SettingsDatabase.RegisterSettings((SettingsBase)(FileDatabase.Get<SettingsRusMBOptionScreen>("RegenerationByJ0schiSettingsRus") ?? new SettingsRusMBOptionScreen()));
                SettingsDatabase.RegisterSettings((SettingsBase)(FileDatabase.Get<SettingsEng>("RegenerationByJ0schiSettingsEng") ?? new SettingsEng()));

                new Harmony("mod.bannerlord.mipen").PatchAll();
               
                /*
                this.regenerationDelay = SettingsEng.Instance.RegenerationDelay;
                this.regenerationValue = SettingsEng.Instance.RegenerationValue;
                this.allHealthRegeneration = SettingsEng.Instance.AllHealthRegeneration;
                this.playerHealthRegeneration = SettingsEng.Instance.PlayerHealthRegeneration;
                this.companionHealthRegeneration = SettingsEng.Instance.CompanionHealthRegeneration;
                this.partyHealthRegeneration = SettingsEng.Instance.PartyHealthRegeneration;
                this.enemyLeaderHealthRegeneration = SettingsEng.Instance.EnemyLeaderHealthRegeneration;
                this.enemyPartyHealthRegeneration = SettingsEng.Instance.EnemyPartyHealthRegeneration;

                debug("Regeneration.SettingsLoaded Sucessfull.");
            }
            catch(Exception ex){
                int num = (int)System.Windows.MessageBox.Show("Error Initialising Bannerlord Tweaks:\n\n" + ex);
            }
            */    
        }
   
        protected override void OnApplicationTick(float dt)
        {
            base.OnApplicationTick(dt);
            regeneration();
        }

        // Дебаг:
        public void debug(String message)
        {
            if(enableMessage)
            {
                InformationManager.DisplayMessage(new InformationMessage(message));
            }
        }

        // Метод выполняет регенерацию здоровья:
        public void regeneration() {

            // Если миссия активна:
            if(Mission.Current != null)
            {
                // Начало миссии:
                if(getAllAgentList().Count > allUnitCount || targetAgentList == null || targetAgentList.Count == 0) {

                    debug("getAllAgentList().Count = " + getAllAgentList().Count);
                    debug("allUnitCount = " + allUnitCount);

                    playerAgent = null;

                    targetAgentList = new List<Agent>();

                    if(Mission.Current.MainAgent != null)
                    {
                        playerAgent = Mission.Current.MainAgent;
                    }

                    List<Agent> allAgent = getAllAgentList();

                    allUnitCount = allAgent.Count;

                    if(playerAgent != null) {

                        debug("Подготовка списка юнитов.");

                        if(playerHealthRegeneration) {
                            targetAgentList.Add(playerAgent);
                            debug("Игрок был добавлен в список.");
                        }

                        // Применяем фильтры:
                        foreach(Agent a in allAgent.ToArray())
                        {
                            if(a.IsHuman) {

                                // Отбор всех только людей:
                                if(allHealthRegeneration) {
                                    targetAgentList.Add(a);
                                    debug("Добавлены все.");
                                    continue;
                                }

                                // Отбор союзных компаньенов и дружественных лордов:
                                if(companionHealthRegeneration) {
                                    if(a.IsFriendOf(playerAgent)) {
                                        if(a.IsHero)
                                        {
                                            targetAgentList.Add(a);
                                            debug("Добавлен союзный герой: " + a.Name);
                                            continue;
                                        }
                                    }
                                }

                                // Отбор союзных солдат кроме компаньенов и лордов:
                                if(partyHealthRegeneration) {
                                    if(a.IsFriendOf(playerAgent)) {
                                        if(!a.IsHero) {
                                            targetAgentList.Add(a);
                                            debug("Добавлен союзный пехотинец: " + a.Name);
                                            continue;
                                        }
                                    }
                                }

                                // Отбор только вражеских лордов:
                                if(enemyLeaderHealthRegeneration) {
                                    if(!a.IsFriendOf(playerAgent)) {
                                        if(a.IsHero) {
                                            targetAgentList.Add(a);
                                            debug("Добавлен вражеский герой: " + a.Name);
                                            continue;
                                        }
                                    }
                                }

                                if(enemyPartyHealthRegeneration) {
                                    if(!a.IsFriendOf(playerAgent)) {
                                        if(!a.IsHero) {
                                            targetAgentList.Add(a);
                                            debug("Добавлен вражеский пехотинец: " + a.Name);
                                            continue;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                startTime = startTime + 1;

                if(startTime >= regenerationDelay * 10)
                {
                    foreach(Agent a in targetAgentList.ToArray())
                    {

                        if(a.Health <= 0)
                            continue;

                        if((double)a.Health < a.HealthLimit)
                        {
                            debug("next Agent in List: " + a.Name);
                            debug(a.Name + " healt = " + a.Health);
                            debug("regenerationValue = " + regenerationValue);
                            if((double)a.Health + regenerationValue <= a.HealthLimit)
                            {
                                a.Health = (a.Health + regenerationValue);
                            }
                            else
                            {
                                a.Health = a.HealthLimit;
                            }
                        }
                    }

                    startTime = 1;
                }
            }
            else {
                // Окончание миссии:
                if(targetAgentList != null)
                {
                    targetAgentList = null;
                }
                allUnitCount = 0;
            }
        }

        // Получение списка всех живых Agent-ов:
        public List<Agent> getAllAgentList()
        {
            List<Agent> resultAgents = Mission.Current.GetNearbyAgents(new Vec2(0.0f, 0.0f), 1E+07f).ToList<Agent>();
            return resultAgents.Count > 0 ? resultAgents : new List<Agent>();
        }

        // Получение списка только компаньенов и союзных лордов:
        public List<Agent> getPartyAgentList()
        {
            List<Agent> resultAgents = Mission.Current.GetNearbyAllyAgents(new Vec2(0.0f, 0.0f), 1E+07f, Mission.Current.MainAgent.Team).ToList<Agent>();
            return resultAgents.Count > 0 ? resultAgents : new List<Agent>();
        }

        // Получение списка противников:
        public List<Agent> getEnemyPartyAgentList()
        {
            List<Agent> resultAgents = Mission.Current.GetNearbyEnemyAgents(new Vec2(0.0f, 0.0f), 1E+07f, Mission.Current.MainAgent.Team).ToList<Agent>();
            return resultAgents.Count > 0 ? resultAgents : new List<Agent>();
        }
    }
}