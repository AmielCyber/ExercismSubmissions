#include "word_count.h"
#include <algorithm>
#include <cctype>
#include <map>
#include <regex>

namespace word_count {
std::map<std::string, int> words(const std::string &sentence) {
  std::map<std::string, int> result{};
  auto words_begin =
      std::sregex_iterator(sentence.begin(), sentence.end(), pattern);
  auto words_end = std::sregex_iterator();
  for (std::sregex_iterator i = words_begin; i != words_end; ++i) {
    std::smatch match = *i;
    std::string match_str = match.str();
    std::transform(match_str.begin(), match_str.end(), match_str.begin(),
                   [](unsigned char c) { return std::tolower(c); });
    if (result.count(match_str) > 0) {
      result.at(match_str) += 1;
    } else {
      result.emplace(match_str, 1);
    }
  }
  return result;
}
} // namespace word_count
