#pragma once
#include <string>
#include <vector>

namespace crypto_square {
class cipher {
public:
  explicit cipher(const std::string &input);
  std::string normalized_cipher_text();

private:
  std::string cipher_text{};
  void normalize_text();
  std::vector<std::string> get_rectangle_vector() const;
};
} // namespace crypto_square
