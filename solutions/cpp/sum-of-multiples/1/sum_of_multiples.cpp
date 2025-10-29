#include "sum_of_multiples.h"
#include <unordered_set>

namespace sum_of_multiples {
// Time Complexity: O(items.length*(level / max(items)))
// Space Complexity: O(items.length*(level / min(items)))
int to(std::vector<int> items, int level) {
  std::unordered_set<int> multiples;
  int multiple_sum = 0;
  for (const int &item : items) {
    for (int multiple = item; multiple < level; multiple += item) {
      if (multiples.find(multiple) == multiples.end()) {
        multiples.insert(multiple);
        multiple_sum += multiple;
      }
    }
  }
  return multiple_sum;
}
} // namespace sum_of_multiples
