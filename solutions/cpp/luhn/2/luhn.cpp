#include "luhn.h"
#include <cctype>

namespace luhn {
bool valid(const std::string &str) {
  long sum = 0;
  std::size_t nth_number = 0;

  for (std::size_t i = str.length(); i > 0; --i) {
    char ch = str[i - 1];
    if (std::isdigit(ch)) {
      ++nth_number;
      int num = static_cast<int>(ch - '0');
      if (nth_number % 2 == 0) {
        num *= 2;
        if (num > 9) {
          num -= 9;
        }
      }
      sum += num;
    } else if (!std::isspace(ch)) {
      return false;
    }
  }
  if ((nth_number == 1 && sum == 0) || nth_number == 0) {
    // Single zero or no numbers found.
    return false;
  }

  return sum % 10 == 0;
}

} // namespace luhn
