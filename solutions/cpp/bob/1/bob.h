#pragma once

#include <string>
namespace bob {
namespace response_to {
const static std::string question = "Sure.";           // 01
const static std::string yelling = "Whoa, chill out!"; // 10
const static std::string yelling_question =
    "Calm down, I know what I'm doing!";                 // 11
const static std::string silence = "Fine. Be that way!"; // 00
const static std::string anything_else = "Whatever.";    // 100
} // namespace response_to
std::string hey(const std::string &sentence);
bool is_silence(const std::string &sentence);
bool is_question(const std::string &sentence);
bool is_yelling(const std::string &sentence);
} // namespace bob
