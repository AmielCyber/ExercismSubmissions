#include "beer_song.h"
#include <string>

namespace beer_song {
std::string verse(int verse_number) {
  return first_part(verse_number) + second_part(verse_number);
}

std::string sing(int start_verse_number, int end_verse_number) {
  std::string verses{};
  for (int verse_number = start_verse_number; verse_number >= end_verse_number;
       --verse_number) {
    verses += verse(verse_number);
    if (verse_number > end_verse_number) {
      verses += "\n";
    }
  }
  return verses;
}

std::string first_part(int verse_number) {
  if (verse_number > 1) {
    return std::to_string(verse_number) + " bottles of beer on the wall, " +
           std::to_string(verse_number) + " bottles of beer.\n";
  }
  if (verse_number == 1) {
    return "1 bottle of beer on the wall, 1 bottle of beer.\n";
  }
  return "No more bottles of beer on the wall, no more bottles of beer.\n";
}

std::string second_part(int verse_number) {
  if (verse_number > 1) {
    std::string verse = "Take one down and pass it around, " +
                        std::to_string(verse_number - 1) + " bottle";
    if (verse_number > 2) {
      verse += "s";
    }
    verse += " of beer on the wall.\n";
    return verse;
  }
  if (verse_number == 1) {
    return "Take it down and pass it around, no more bottles of beer on the "
           "wall.\n";
  }
  return "Go to the store and buy some more, 99 bottles of beer on the wall.\n";
}

} // namespace beer_song
