using System;
using System.Collections.Generic;

namespace EE.AbilitySystem.Components {
    public static class AbilityDataDictonary {
        private static Dictionary<Guid, AbilityData> InitedAbilities = new Dictionary<Guid, AbilityData>();

        public static void Add(Guid guid, AbilityData abilityData) {
            if (InitedAbilities.ContainsKey(guid)) {
                InitedAbilities[guid] = abilityData;
            }
            else {
                InitedAbilities.Add(guid, abilityData);
            }
        }
        public static bool TryGet(Guid guid, out AbilityData abilityData) {
            return InitedAbilities.TryGetValue(guid, out abilityData);
            
        }
    }
}

