#include "anagram.h"
#include <cctype>
#include <cstddef>
#include <vector>

namespace anagram {
anagram::anagram(const std::string &word) {
  std::string w{};
  alpha_letter_count.fill(0);
  for (const char &c : word) {
    char lower_c = tolower(c);
    std::size_t index = static_cast<std::size_t>(lower_c - 'a');

    alpha_letter_count.at(index)++;
    w += tolower(lower_c);
  }
  target_word = w;
}

std::vector<std::string>
anagram::matches(const std::vector<std::string> &words) const {
  std::vector<std::string> matched_words{};
  for (const std::string &word : words) {
    if (match(word)) {
      matched_words.push_back(word);
    }
  }
  return matched_words;
}

bool anagram::match(const std::string &word) const {
  std::array<std::size_t, 26> alphabet_count{};
  alphabet_count.fill(0);
  std::string lower_case_word{};
  lower_case_word.reserve(word.length());
  for (const char &c : word) {
    char lower_c = tolower(c);
    std::size_t index = static_cast<std::size_t>(lower_c - 'a');
    alphabet_count.at(index)++;
    lower_case_word += lower_c;
  }
  return lower_case_word != target_word && alphabet_count == alpha_letter_count;
}
} // namespace anagram
