#include "bob.h"
#include <cctype>
#include <string>

namespace bob {
std::string hey(const std::string &sentence) {
  if (is_silence(sentence)) {
    return response_to::silence;
  }
  if (is_yelling(sentence)) {
    if (is_question(sentence)) {
      return response_to::yelling_question;
    }
    return response_to::yelling;
  }
  if (is_question(sentence)) {
    return response_to::question;
  }
  return response_to::anything_else;
}

bool is_silence(const std::string &sentence) {
  for (char ch : sentence) {
    if (!std::isspace(ch)) {
      return false;
    }
  }
  return true;
}

bool is_question(const std::string &sentence) {
  auto beg = sentence.find('?');
  if (beg == std::string::npos) {
    return false;
  }
  for (size_t pos = beg; pos < sentence.length(); ++pos) {
    if (std::isalnum(sentence.at(pos))) {
      return false;
    }
  }
  return true;
}

bool is_yelling(const std::string &sentence) {
  bool has_alpha = false;
  for (char ch : sentence) {
    if (std::isalpha(ch)) {
      if (std::islower(ch)) {
        return false;
      }
      has_alpha = true;
    }
  }
  return has_alpha;
}
} // namespace bob
