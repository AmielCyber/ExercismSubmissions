#pragma once
#include <array>
#include <cstddef>
#include <string>
#include <vector>

namespace anagram {
class anagram {
private:
  std::string target_word;
  std::array<std::size_t, 26> alpha_letter_count{};
  bool match(const std::string &word) const;

public:
  anagram(const std::string &word);
  std::vector<std::string> matches(const std::vector<std::string> &words) const;
};

// TODO: add your solution here

} // namespace anagram
