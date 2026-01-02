#include "series.h"
#include <cstddef>
#include <stdexcept>
#include <vector>

namespace series {
std::vector<std::string> slice(const std::string &digits, const int length) {
  if (digits.empty()) {
    throw std::domain_error("Digits must not be empty.");
  }
  if (static_cast<size_t>(length) > digits.size()) {
    throw std::domain_error("Length must be less than digits size.");
  }
  if (length <= 0) {
    throw std::domain_error("Length must be greater than 0.");
  }
  std::vector<std::string> result{};
  for (size_t left_ptr = 0; left_ptr + length <= digits.size(); ++left_ptr) {
    result.emplace_back(digits.substr(left_ptr, length));
  }
  return result;
}
} // namespace series
