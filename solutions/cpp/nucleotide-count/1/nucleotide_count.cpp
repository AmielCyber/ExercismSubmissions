#include "nucleotide_count.h"
#include <map>
#include <stdexcept>
#include <string>

namespace nucleotide_count {

// TODO: add your solution here
std::map<char, int> count(const std::string &strand) {
  // A, C, G, or T
  std::map<char, int> map = {{'A', 0}, {'C', 0}, {'G', 0}, {'T', 0}};
  for (char nucl : strand) {
    auto count = map.find(nucl);
    if (count != map.end()) {
      count->second = count->second + 1;
    } else {
      throw std::invalid_argument(
          "Only values 'A', 'C', 'G', and 'T' are allowed");
    }
  }
  return map;
}

} // namespace nucleotide_count
