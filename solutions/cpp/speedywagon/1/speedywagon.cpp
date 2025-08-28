#include "speedywagon.h"
#include <cstddef>

namespace speedywagon {

// Enter your code below:

// Please don't change the interface of the uv_light_heuristic function
int uv_light_heuristic(std::vector<int> *data_array) {
  double avg{};
  for (auto element : *data_array) {
    avg += element;
  }
  avg /= data_array->size();
  int uv_index{};
  for (auto element : *data_array) {
    if (element > avg)
      ++uv_index;
  }
  return uv_index;
}
bool connection_check(pillar_men_sensor *pSensor) { return pSensor != nullptr; }

int activity_counter(pillar_men_sensor *const pSensorStart, int capacity) {
  int total_activity = 0;
  pillar_men_sensor *pSensor = pSensorStart;
  for (int i = 0; i < capacity; ++i, ++pSensor) {
    total_activity += pSensor->activity;
  }
  return total_activity;
}

bool alarm_control(const pillar_men_sensor *pSensor) {
  return pSensor != nullptr && pSensor->activity > 0;
}

bool uv_alarm(pillar_men_sensor *pSensor) {
  return pSensor != nullptr &&
         uv_light_heuristic(&(pSensor->data)) > pSensor->activity;
}

} // namespace speedywagon
