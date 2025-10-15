#include "collatz_conjecture.h"
#include <stdexcept>

namespace collatz_conjecture {
int steps(int num) {
  if (num < 1)
    throw std::domain_error("Num must be greater than 1");
  int step = 0;
  while (num > 1) {
    if (num % 2 == 0) {
      num /= 2;
    } else {
      num = num * 3 + 1;
    }
    step++;
  }
  return step;
}
} // namespace collatz_conjecture
