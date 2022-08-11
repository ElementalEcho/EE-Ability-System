using EE.AbilitySystem.Components;
using EE.Core;
using UnityEngine;

namespace EE.AbilitySystem.Actions {
    public class AbilityCooldownActionSO : GenericActionSO<AbilityCooldownAction> {
        [SerializeField]
        private AbilitySO abilitySO = null;
        public AbilitySO AbilitySO => abilitySO;
    }
    public class AbilityCooldownAction : GenericAction {
        private AbilityCooldownActionSO OriginSO => (AbilityCooldownActionSO)_originSO;
        private AbilityComponent abilityComponent;

        public override void Init(IHasComponents hasComponents) {
            abilityComponent = hasComponents.GetComponent<AbilityComponent>();
        }
        protected override bool Decide() {
            var readyToUse = abilityComponent.IsReadyToUse(OriginSO.AbilitySO);
            return readyToUse;
        }
        public override void Enter() {
            abilityComponent.AddCooldown(OriginSO.AbilitySO);
        }
    }
}