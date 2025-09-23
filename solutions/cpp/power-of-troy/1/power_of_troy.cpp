#include "power_of_troy.h"
#include <cstddef>
#include <memory>

namespace troy {
void give_new_artifact(human &r_human, std::string artifact_name) {
  r_human.possession = std::make_unique<artifact>(artifact_name);
}
void exchange_artifacts(std::unique_ptr<artifact> &human_one,
                        std::unique_ptr<artifact> &human_two) {
  artifact *p_one = human_one.release();
  artifact *p_two = human_two.release();
  human_one.reset(p_two);
  human_two.reset(p_one);
}
void manifest_power(human &r_human, std::string power_name) {
  r_human.own_power = std::make_shared<power>(power_name);
}

void use_power(human &caster, human &target) {
  target.influenced_by = caster.own_power;
}
int power_intensity(human &h) {
  return h.own_power != nullptr ? h.own_power.use_count() : 0;
}

} // namespace troy
