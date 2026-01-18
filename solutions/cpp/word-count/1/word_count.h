#pragma once

#include <map>
#include <regex>
#include <string>
#include <unordered_map>
namespace word_count {
const std::regex pattern{R"((\b[a-zA-Z]+\'?[a-zA-Z]*\b)|(\d+))"};
std::map<std::string, int> words(const std::string &sentence);
} // namespace word_count
