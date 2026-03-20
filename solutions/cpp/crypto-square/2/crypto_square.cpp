#include "crypto_square.h"
#include <cmath>
#include <iostream>
#include <ostream>
#include <string>
#include <vector>
#include <algorithm>
using std::string;
using std::vector;

namespace crypto_square {
  cipher::cipher(const string &input) : cipher_text(input) {
  }

  std::string cipher::normalized_cipher_text() {
    normalize_text();
    vector<string> rectangle = get_rectangle_vector();
    string result{};
    if (rectangle.empty() || rectangle.back().empty()) {
      return result;
    }
    size_t column_size = rectangle.front().size();
    for (size_t col = 0; col < column_size; ++col) {
      for (string &row_string: rectangle) {
        if (col < row_string.size()) {
          result += row_string.at(col);
        }else {
          // If is not the perfect square string
          result += " ";
        }
      }
      if (col < column_size - 1) {
        // If we are not at the end of the sentence
        result += " ";
      }
    }
    return result;
  }

  void cipher::normalize_text() {
    if (cipher_text.empty()) {
      return;
    }
    auto is_not_alpha_num = [](char c) {
      return !std::isalnum(c);
    };
    cipher_text.erase(std::remove_if(cipher_text.begin(), cipher_text.end(), is_not_alpha_num), cipher_text.end());
    for (char &c: cipher_text) {
      c = static_cast<char>(std::tolower(c));
    }
  }

  vector<string> cipher::get_rectangle_vector() const {
    vector<string> rect{};
    if (cipher_text.empty()) {
      return rect;
    }
    auto const rows = static_cast<size_t>(std::round(std::sqrt(cipher_text.size())));
    auto const columns = static_cast<size_t>(
      std::ceil(static_cast<double>(cipher_text.size()) / static_cast<double>(rows)));
    int diff = static_cast<int>(columns) - static_cast<int>(rows);

    size_t left = 0;
    size_t right = columns;
    while (left < cipher_text.size()) {
      string chunk{};
      if (diff > 0 && rows - rect.size() == static_cast<size_t>(diff)) {
        // Last words will be off by one letter to have a perfect square.
        --right;
        --diff;
      }
      chunk = cipher_text.substr(left, right - left);
      rect.emplace_back(chunk);
      std::cout << chunk << std::endl;

      left = right;
      right += columns;
    }
    return rect;
  }
} // namespace crypto_square
