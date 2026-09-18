#include "acronym.h"
#include <cctype>
#include <regex>

namespace acronym {
std::string acronym(const std::string &word) {
  std::regex delimiter("[ ,_-]+");
  // -1 To return the text between the regex matches instead of the matches.
  std::sregex_token_iterator iter(word.begin(), word.end(), delimiter, -1);
  // Default iterator is end
  std::sregex_token_iterator end;
  std::string acro{};

  for (; iter != end; ++iter) {
    const std::string token = iter->str();
    if (!token.empty()) {
      acro += toupper(static_cast<unsigned char>(token[0]));
    }
  }

  return acro;
}

} // namespace acronym
