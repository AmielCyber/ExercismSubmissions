#include "rotational_cipher.h"
#include <cctype>
#include <stdexcept>
#include <string>

namespace rotational_cipher {
// TODO: add your solution here

std::string rotate(const std::string &str, int rotation_num) {
  if (rotation_num < 0) {
    throw std::invalid_argument("Rotation number must be positive.");
  }

  rotation_num = rotation_num % 26;
  std::string str_cipher{};
  for (auto ch : str) {
    if (std::isalpha(ch)) {
      char base = std::isupper(ch) ? 'A' : 'a';
      // Get 0 - 25 index then turn back to char
      char shifted_letter =
          static_cast<char>(base + ((ch - base + rotation_num) % 26));
      str_cipher += shifted_letter;
    } else {
      str_cipher += ch;
    }
  }
  return str_cipher;
}
} // namespace rotational_cipher
