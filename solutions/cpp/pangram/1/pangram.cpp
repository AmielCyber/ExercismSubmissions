#include "pangram.h"
#include <array>
#include <cctype>

namespace pangram {
bool is_pangram(std::string word) {
  std::array<bool, 26> letters{};
  for (char letter : word) {
    char low_case = std::tolower(static_cast<unsigned char>(letter));
    if (std::isalpha(low_case)) {
      int letterIndex = static_cast<int>(low_case - 'a');
      letters[letterIndex] = true;
    }
  }
  for (bool hasLetter : letters) {
    if (!hasLetter) {
      return false;
    }
  }
  return true;
}

} // namespace pangram
