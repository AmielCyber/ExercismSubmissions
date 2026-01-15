#include "roman_numerals.h"
#include <array>

namespace roman {
const std::array one{"",  "I",  "II",  "III",  "IV",
                     "V", "VI", "VII", "VIII", "IX"};
const std::array ten = {"",  "X",  "XX",  "XXX",  "XL",
                        "L", "LX", "LXX", "LXXX", "XC"};
const std::array hundred = {"",  "C",  "CC",  "CCC",  "CD",
                            "D", "DC", "DCC", "DCCC", "CM"};
const std::array thousand = {"", "M", "MM", "MMM"};
}; // namespace roman

namespace roman_numerals {
std::string convert(int num) {
  if (num <= 0 || num > 3999) {
    return "";
  }
  std::string result{};
  if (num >= 1000) {
    result += roman::thousand.at(num / 1000);
    num %= 1000;
  }
  if (num >= 100) {
    result += roman::hundred.at(num / 100);
    num %= 100;
  }
  if (num >= 10) {
    result += roman::ten.at(num / 10);
    num %= 10;
  }
  if (num >= 1) {
    result += roman::one.at(num);
  }
  return result;
}
} // namespace roman_numerals
