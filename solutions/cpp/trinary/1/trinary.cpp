#include "trinary.h"

namespace trinary {
int to_decimal(std::string tri_num) {
  // Check string size for possible int overflow
  int result = 0;
  int exponent = tri_num.size() - 1;

  for (const char char_digit : tri_num) {
    int digit = static_cast<int>(char_digit) - static_cast<int>('0');
    if (digit < 0 || digit > 10) {
      return 0;
    }
    result += pow(3, exponent) * digit;
    --exponent;
  }
  return result;
}
} // namespace trinary
