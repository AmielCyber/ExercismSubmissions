#pragma once

namespace triangle {
enum class flavor {
  equilateral,
  isosceles,
  scalene,
};
flavor kind(double side1, double side2, double side3);
void assert_is_triangle(double a, double b, double c);
bool is_equilateral(double a, double b, double c);
bool is_isosceles(double a, double b, double c);
bool is_scalene(double a, double b, double c);

} // namespace triangle
