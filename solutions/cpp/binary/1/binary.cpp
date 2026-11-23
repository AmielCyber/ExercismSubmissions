#include "binary.h"

namespace binary {

size_t convert(const std::string bin) {
  size_t lol{0};
  for (size_t index = 0; index < bin.size(); ++index) {
    if (bin[index] == '1') {
      lol |= 1;
    } else if (bin[index] != '0') {
      return 0;
    }
    if (index != bin.size() - 1) {
      lol <<= 1;
    }
  }
  return lol;
}
} // namespace binary
