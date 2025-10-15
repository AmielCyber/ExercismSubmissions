#include "protein_translation.h"
#include <string>
using std::string;
#include <vector>
using std::vector;

namespace protein_translation {
vector<string> proteins(string codons) {
  vector<string> result;
  for (int i = 0; i < static_cast<int>(codons.length()); i += 3) {
    if (i + 2 < static_cast<int>(codons.length())) {
      string codon = codons.substr(i, 3);
      string protein = get_protein(codon);
      if (protein == "STOP") {
        break;
      }
      if (protein != "") {
        result.push_back(protein);
      }
    }
  }
  return result;
}
string get_protein(string &codon) {
  if (codon == "AUG") {
    return "Methionine";
  }
  if (codon == "UUU" || codon == "UUC") {
    return "Phenylalanine";
  }
  if (codon == "UUA" || codon == "UUG") {
    return "Leucine";
  }
  if (codon == "UCU" || codon == "UCC" || codon == "UCA" || codon == "UCG") {
    return "Serine";
  }
  if (codon == "UAU" || codon == "UAC") {
    return "Tyrosine";
  }
  if (codon == "UGU" || codon == "UGC") {
    return "Cysteine";
  }
  if (codon == "UGG") {
    return "Tryptophan";
  }
  if (codon == "UAA" || codon == "UAG" || codon == "UGA") {
    return "STOP";
  }
  return "";
}
} // namespace protein_translation
