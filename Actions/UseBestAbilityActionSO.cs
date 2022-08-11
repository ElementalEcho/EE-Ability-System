using EE.Core;

namespace EE.AbilitySystem.Actions {
    public class UseBestAbilityActionSO : GenericActionSO<UseBestAbilityAction> {
    }
    public class UseBestAbilityAction : GenericAction {
        private UseBestAbilityActionSO OriginSO => (UseBestAbilityActionSO)_originSO;
        private IAbilityManager abilityManager;

        public override void Init(IHasComponents controller) {
            abilityManager = controller.GetComponent<IAbilityManager>();
        }
        public override void Enter() {
            abilityManager.UseFirstAvailableAbility();
        }

    }
}