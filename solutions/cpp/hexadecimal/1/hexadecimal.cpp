#include "hexadecimal.h"
#include <cctype>
#include <string>

namespace hexadecimal {
// TODO: add your solution here
int convert(const std::string &str) {
  int hex{0};
  int exp{0};
  for (auto it = str.rbegin(); it != str.rend(); ++it) {
    int num{};
    if (std::isdigit(*it)) {
      num = *it - '0';
    } else if (std::isalpha(*it)) {
      num = std::tolower(*it) - 'a' + 10;
      if (num < 10 || num > 15) {
        return 0;
      }
    } else {
      return 0;
    }
    hex += num * std::pow(16, exp);
    ++exp;
  }
  return hex;
}
} // namespace hexadecimal
