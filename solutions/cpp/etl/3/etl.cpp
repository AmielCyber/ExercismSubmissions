#include "etl.h"
#include <cctype>

namespace etl {
// TODO: add your solution here
std::map<char, int> transform(const std::map<int, std::vector<char>> &old) {
  std::map<char, int> updated{};
  for (auto [point, chars] : old) {
    for (auto letter : chars) {
      char lower_case = std::tolower(letter);
      if (updated.count(lower_case) > 0) {
        updated.at(lower_case) = point;
      } else {
        updated[lower_case] = point;
      }
    }
  }

  return updated;
}

} // namespace etl
