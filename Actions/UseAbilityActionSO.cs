using EE.Core;

namespace EE.AbilitySystem.Actions {
    public class UseAbilityActionSO : GenericActionSO<UseAbilityAction> {
    }
    public class UseAbilityAction : GenericAction {
        private UseAbilityActionSO OriginSO => (UseAbilityActionSO)_originSO;
        private IAbilityManager abilityManager;

        public override void Init(IHasComponents controller) {
            abilityManager = controller.GetComponent<IAbilityManager>();
        }
        public override void Enter() {
            abilityManager.DoAbility();
        }

    }
}