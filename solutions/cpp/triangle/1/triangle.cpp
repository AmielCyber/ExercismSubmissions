#include "triangle.h"
#include <stdexcept>

namespace triangle {
flavor kind(double a, double b, double c) {
  assert_is_triangle(a, b, c);
  if (is_equilateral(a, b, c)) {
    return flavor::equilateral;
  }
  if (is_isosceles(a, b, c)) {
    return flavor::isosceles;
  }
  if (is_scalene(a, b, c)) {
    return flavor::scalene;
  }
  throw std::domain_error("Unexpected unreachable code.");
}

void assert_is_triangle(double a, double b, double c) {
  if (a == 0 || b == 0 || c == 0) {
    throw std::domain_error("Tringle sides must be a positive number.");
  }
  if (a + b < c || b + c < a || a + c < b) {
    throw std::domain_error("Sides do not make a triangle");
  }
}

bool is_equilateral(double a, double b, double c) { return a == b && b == c; }
bool is_isosceles(double a, double b, double c) {
  return a == b || b == c || a == c;
}
bool is_scalene(double a, double b, double c) { return !is_isosceles(a, b, c); }

} // namespace triangle
