#include "grains.h"
#include <cmath>

namespace grains {
// TODO: add your solution here
unsigned long square(int sq) { return pow(2UL, sq - 1); }

unsigned long total() { return pow(2UL, 64UL); }
} // namespace grains
