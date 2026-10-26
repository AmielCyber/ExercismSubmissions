#include "armstrong_numbers.h"
#include <cmath>
#include <string>

namespace armstrong_numbers {
bool is_armstrong_number(int num) {
  std::string str_num = std::to_string(num);
  int armstrong_num = 0;
  const int exp = str_num.length();
  for (const auto &digit : str_num) {
    int base = static_cast<int>(digit - '0');
    armstrong_num += std::pow(base, exp);
  }
  return armstrong_num == num;
}

} // namespace armstrong_numbers
