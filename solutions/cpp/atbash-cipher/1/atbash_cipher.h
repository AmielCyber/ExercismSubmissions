#pragma once

#include <string>
namespace atbash_cipher {
std::string encode(const std::string &str);
std::string decode(const std::string &str);
std::string add_spacing(const std::string &str, const int space_num);
} // namespace atbash_cipher
