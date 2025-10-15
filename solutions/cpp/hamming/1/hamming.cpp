#include "hamming.h"
#include <stdexcept>
#include <string>

namespace hamming {

// TODO: add your solution here
int compute(std::string strand1, std::string strand2) {
  if (strand1.size() != strand2.size())
    throw std::domain_error("Strands must be the same length.");
  int distance = 0;
  for (size_t i = 0; i < strand1.size(); ++i) {
    if (strand1[i] != strand2[i]) {
      ++distance;
    }
  }
  return distance;
}

} // namespace hamming
