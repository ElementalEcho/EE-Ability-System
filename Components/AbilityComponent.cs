using EE.Core;
using System.Collections.Generic;
using UnityEngine;

namespace EE.AbilitySystem.Components {

    public class AbilityComponent : MonoBehaviour , IAbilityManager, IHasComponents {
        [SerializeField]
        private Dictionary<AbilitySO, AbilityCooldown> statuses = new Dictionary<AbilitySO, AbilityCooldown>();

        private IAbilityManager abilityManager;

        public Ability CurrentAbility => abilityManager.CurrentAbility;

        [SerializeField]
        private AbilityManagerSO abilityManagerSO;
        [SerializeField]
        private List<AbilitySO> abilitySOs = new List<AbilitySO>();

        void Start() {

            if (abilityManagerSO != null) {
                abilityManager = abilityManagerSO;
                foreach (var abilitySO in abilitySOs) {
                    var ability = abilitySO.Get(this);
                    abilityManagerSO.AddAbility(ability);
                }
            }
            else {
                var abilityContainment = new AbilityContainer();

                foreach (var abilitySO in abilitySOs) {
                    var ability = abilitySO.Get(this);
                    abilityContainment.AddAbility(ability);
                }
                abilityManager =  new AbilityManager(abilityContainment);
            }
        }


        public void CustomUpdate(float tickSpeed) {
            List<AbilitySO> removals = new List<AbilitySO>();

            foreach (var keyValuePair in statuses) {
                AbilityCooldown statusEffect = keyValuePair.Value;
                statusEffect.Duration -= tickSpeed;
                if (statusEffect.Duration <= 0) {
                    removals.Add(keyValuePair.Key);
                }
            }
            foreach (var item in removals) {
                statuses.Remove(item);
            }
        }
        public void AddCooldown(AbilitySO abilitySO) {
            var abilityCooldown = new AbilityCooldown();
            abilityCooldown.Duration = abilitySO.cooldown;

            if (statuses.TryAdd(abilitySO, abilityCooldown)) {
                Debug.Log($"Failed to add {abilitySO}.");
            }
        }
        public bool IsReadyToUse(AbilitySO abilitySO) {
            return !statuses.ContainsKey(abilitySO);
        }

        public bool RequirementsTrue() {
            return abilityManager.RequirementsTrue();
        }

        public void DoAbility() {
            abilityManager.DoAbility();
        }

        public void SetIndex(int index) {
            abilityManager.SetIndex(index);
        }

        public void AddIndexChangedEvent(AbilityDelegate.EEDelegate eEDelegate) {
            abilityManager.AddIndexChangedEvent(eEDelegate);
        }

        public void UseFirstAvailableAbility() {
            abilityManager.UseFirstAvailableAbility();
        }
    }
    [System.Serializable]
    public class AbilityCooldown {
        public float Duration;

    }

}