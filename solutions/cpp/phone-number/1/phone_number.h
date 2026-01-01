#pragma once

#include <regex>
#include <string>
namespace phone_number {
class phone_number {
public:
  phone_number(std::string input);
  std::string number();

private:
  std::string phone_number_str;
  static std::regex PATTERN;
  std::string extract_numbers(const std::smatch &matches);
};
} // namespace phone_number
