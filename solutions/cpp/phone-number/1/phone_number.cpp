#include "phone_number.h"
#include <cctype>
#include <regex>
#include <stdexcept>
#include <string>

namespace phone_number {
std::regex phone_number::phone_number::PATTERN{
    R"(\s*(\+1|1)?\s*(\([2-9]\d{2}\)|[2-9]\d{2})(\s*|\-|\.)([2-9]\d{2})(\s*|\-|\.)(\d{4}\s*))"};
phone_number::phone_number::phone_number::phone_number(std::string input) {
  std::smatch matches{};
  if (std::regex_match(input, matches, PATTERN)) {
    phone_number_str = extract_numbers(matches);
    if (phone_number_str.size() >= 11) {
      if (phone_number_str.at(0) == '1') {
        phone_number_str = phone_number_str.substr(1);
      } else {
        throw std::domain_error("Invalid input.");
      }
    }
  } else {
    throw std::domain_error("Invalid input.");
  }
}

std::string
phone_number::phone_number::extract_numbers(const std::smatch &matches) {
  std::string num{};
  if (!matches.empty()) {
    std::string str = matches[0].str();
    for (char ch : str) {
      if (std::isdigit(ch)) {
        num += ch;
      }
    }
  }
  return num;
}

std::string phone_number::phone_number::number() { return phone_number_str; }

} // namespace phone_number
