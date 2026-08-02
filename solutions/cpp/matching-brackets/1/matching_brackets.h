#pragma once
#include <string>
#include <unordered_map>
#include <unordered_set>

namespace matching_brackets {
const std::unordered_set<char> is_left_bracket{'[', '{', '('};
const std::unordered_map<char, char> right_bracket_pair{
    {']', '['}, {'}', '{'}, {')', '('}};
bool check(const std::string &str);
} // namespace matching_brackets
