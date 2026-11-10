#pragma once

namespace darts {
static double inner_circle_radius{1};
static double middle_circle_radius{5};
static double outer_circle_radius{10};

double get_radius(const double x, const double y);
int score(double x, double y);
} // namespace darts
