#include "matching_brackets.h"
#include <stack>
#include <unordered_map>

namespace matching_brackets {
// TODO: add your solution here
bool check(const std::string &str) {
  std::stack<char> left_brackets{};
  for (const char c : str) {
    if (is_left_bracket.count(c) > 0) {
      left_brackets.push(c);
    } else if (right_bracket_pair.count(c) > 0) {
      if (left_brackets.size() == 0) {
        return false;
      }
      if (left_brackets.top() != right_bracket_pair.at(c)) {
        return false;
      }
      left_brackets.pop();
    }
  }
  return left_brackets.size() == 0;
}

} // namespace matching_brackets
