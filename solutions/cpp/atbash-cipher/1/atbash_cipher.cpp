#include "atbash_cipher.h"
#include <array>
#include <cctype>
#include <cstddef>

namespace atbash_cipher {
const int OFFSET = static_cast<int>('a');
const int WORD_SPACING = 5;
const std::array<char, 26> alph_arr = {
    'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm',
    'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};

std::string encode(const std::string &str) {
  return add_spacing(decode(str), WORD_SPACING);
}

std::string decode(const std::string &str) {
  std::string decoded_str{};
  for (size_t i = 0; i < str.length(); ++i) {
    if (std::isalnum(str[i])) {
      if (std::isalpha(str[i])) {
        int index = alph_arr.size() - 1 -
                    (static_cast<int>(std::tolower(str[i])) - OFFSET);
        decoded_str += alph_arr[index];
      } else if (std::isdigit(str[i])) {
        decoded_str += str[i];
      }
    }
  }
  return decoded_str;
}

std::string add_spacing(const std::string &str, const int space_num) {
  if (space_num <= 0) {
    throw std::invalid_argument("Space number must be greater than 0.");
  }
  std::string spaced_str{};
  for (size_t i = 0; i < str.size(); ++i) {
    if (i > 0 && i % space_num == 0) {
      spaced_str += ' ';
    }
    spaced_str += str[i];
  }
  return spaced_str;
}
} // namespace atbash_cipher
