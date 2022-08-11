using EE.AbilitySystem;
using EE.Core;
using UnityEngine;

namespace EE.AbilitySystem.Components {
    public class AbilitySO : ScriptableObject {


        public Sprite Icon;
        public float cooldown;

        public DecisionGroupSO requirementSOs = new DecisionGroupSO();

        public GenericActionSO[] genericActionSOs = new GenericActionSO[0];

        public Ability Get(IHasComponents hasComponents) {
            var useEffect = new AbilityDelegate();
            var genericActions = genericActionSOs.GetActions(hasComponents);
            foreach (var genericAction in genericActions) {
                useEffect.Add(genericAction.Enter);
            }

            var boolEvent = new RequirementDelegate();
            var decisionGroup = requirementSOs.GetDecisionGroup(hasComponents);
            boolEvent.Add(decisionGroup.Decide);
            
            var ability = new Ability(boolEvent, useEffect);

            AbilityDataDictonary.Add(ability.ID, new AbilityData(Icon));
            return ability;
        }
    }

    public class AbilityData {
        public Sprite Icon;

        public AbilityData(Sprite icon) {
            Icon = icon;
        }
    }
}

