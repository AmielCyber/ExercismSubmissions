#include "reverse_string.h"
#include <string>

namespace reverse_string {

// TODO: add your solution here
std::string reverse_string(std::string str) {
  std::string rev_str{};
  for (int i = str.size() - 1; i >= 0; --i) {
    rev_str += str[i];
  }
  return rev_str;
}

} // namespace reverse_string
