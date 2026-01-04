#include "food_chain.h"
#include <string>

namespace food_chain {
std::string verse(size_t verse_number) {
  std::string song = "I know an old lady who swallowed a ";
  song += food_info::animal.at(verse_number) + '.' + '\n';
  song += food_info::animal_adj.at(verse_number) + '\n';

  if (verse_number == food_info::LAST_VERSE ||
      verse_number == food_info::FIRST_VERSE) {
    return song;
  }
  for (; verse_number > food_info::FIRST_VERSE; --verse_number) {
    song += "She swallowed the " + food_info::animal.at(verse_number) +
            " to catch the " + food_info::animal.at(verse_number - 1);
    if (verse_number != food_info::SPIDER_VERSE) {
      song += ".\n";
    } else {
      song += " that wriggled and jiggled and tickled inside her.\n";
    }
  }
  song += food_info::animal_adj.at(food_info::FIRST_VERSE) + '\n';
  return song;
}
std::string verses(size_t start_verse_num, size_t end_verse_num) {
  std::string song{};
  for (size_t curr_verse = start_verse_num; curr_verse <= end_verse_num;
       ++curr_verse) {
    song += verse(curr_verse) + '\n';
  }
  return song;
}
std::string sing() { return verses(1, 8); }

} // namespace food_chain
