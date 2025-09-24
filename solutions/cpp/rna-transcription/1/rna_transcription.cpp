#include "rna_transcription.h"
#include <stdexcept>
#include <string>

namespace rna_transcription {
char to_rna(char dna) {
  switch (dna) {
  case 'G':
    return 'C';
  case 'C':
    return 'G';
  case 'T':
    return 'A';
  case 'A':
    return 'U';
  default:
    std::string msg = "'" + std::to_string(dna) + "'" + " is not valid.";
    throw std::invalid_argument(msg);
  }
}
std::string to_rna(const std::string &dna) {
  std::string result{};
  for (char ch : dna) {
    result.push_back(to_rna(ch));
  }
  return result;
}

} // namespace rna_transcription
