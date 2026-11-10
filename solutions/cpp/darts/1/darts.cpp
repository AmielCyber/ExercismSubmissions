#include "darts.h"
#include <cmath>

namespace darts {
double get_radius(const double x, const double y) {
  return std::sqrt(x * x + y * y);
}

int score(double x, double y) {
  const double radius = get_radius(x, y);
  if (radius <= inner_circle_radius) {
    return 10;
  } else if (radius <= middle_circle_radius) {
    return 5;
  } else if (radius <= outer_circle_radius) {
    return 1;
  }
  return 0;
}
} // namespace darts
