#include "binary_search.h"
#include <cstddef>
#include <stdexcept>
#include <vector>

namespace binary_search {
std::size_t find(const std::vector<int> &data, int num) {
  int lo = 0;
  int hi = data.size() - 1;

  while (lo <= hi) {
    const int mid = lo + (hi - lo) / 2;
    if (data.at(mid) == num) {
      return static_cast<std::size_t>(mid);
    } else if (data.at(mid) < num) {
      lo = mid + 1;
    } else {
      hi = mid - 1;
    }
  }
  throw std::domain_error("Not Found.");
}
} // namespace binary_search
