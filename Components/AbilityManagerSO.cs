using System.Collections.Generic;
using UnityEngine;
using static EE.AbilitySystem.AbilityDelegate;

namespace EE.AbilitySystem.Components {

    public class AbilityManagerSO : ScriptableObject, IAbilityManager {

        public int NumberOfAbilities => abilityContainer.NumberOfAbilities;



        private AbilityContainer abilityContainer = new AbilityContainer();
        private IAbilityManager abilityManager;

        public IAbilityManager AbilityManager { 
            get {
                if (abilityManager == null) {
                    abilityManager = new AbilityManager(abilityContainer);
                }
                return abilityManager; 
            } 
        }
        public Ability CurrentAbility => AbilityManager.CurrentAbility;

        public void AddIndexChangedEvent(EEDelegate eEDelegate) {
            AbilityManager.AddIndexChangedEvent(eEDelegate);
        }
        public void AbilityAddedEventdEvent(EEDelegate eEDelegate) {
            abilityContainer.AbilityAddedEvent.Add(eEDelegate);
        }
        public void AbilityRemovedEventdEvent(EEDelegate eEDelegate) {
            abilityContainer.AbilityRemovedEvent.Add(eEDelegate);
        }
        public bool RequirementsTrue() {
            return AbilityManager.RequirementsTrue();
        }

        public void DoAbility() {
            AbilityManager.DoAbility();
        }
        public void UseFirstAvailableAbility() {
            abilityManager.UseFirstAvailableAbility();
        }
        public void SetIndex(int index) {
            AbilityManager.SetIndex(index);
        }

        public void AddAbility(Ability ability) {
            abilityContainer.AddAbility(ability);
        }

        public void OpenSpellWheel() {
            if (abilityContainer.NumberOfAbilities <= 0) {
                return;
            }
            //SceneController.LoadNewScene(SceneController.SpellWheelSceneName,false);
        }
        public void CloseSpellMenu() {
            if (abilityContainer.NumberOfAbilities <= 0) {
                return;
            }
            //SceneController.UnloadScene(SceneController.SpellWheelSceneName);
        }
        public List<Ability> GetAbilities() {
            int numberOfAbilities = abilityContainer.NumberOfAbilities;

            List<Ability> abilities = new List<Ability>();
            for (int i = 0; i < numberOfAbilities; i++) {
                var ability = abilityContainer.Get(i);
                abilities.Add(ability);
            }
            return abilities;
        }
    }
}