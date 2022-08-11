using EE.AbilitySystem.Components;
using EE.Core;
using UnityEngine;

namespace EE.AbilitySystem.Actions {
    public class AddAbilityActionSO : GenericActionSO<AddAbilityAction> {
        [SerializeField]
        public AbilityManagerSO spellContainerSO = null;
        public AbilityManagerSO SpellContainer => spellContainerSO;
        [SerializeField]
        public AbilitySO abilitySO = null;
        public AbilitySO AbilitySO => abilitySO;
    }
    public class AddAbilityAction : GenericAction {
        private AddAbilityActionSO OriginSO => (AddAbilityActionSO)_originSO;

        Ability ability;

        public override void Init(IHasComponents hasComponents) {
            ability = OriginSO.AbilitySO.Get(hasComponents);
        }
        public override void Enter() {
            OriginSO.SpellContainer.AddAbility(ability);
        } 

    }
}