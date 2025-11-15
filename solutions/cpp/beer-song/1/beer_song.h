#pragma once
#include <string>

namespace beer_song {
std::string verse(int verse_number);
std::string sing(int start_verse_number, int end_verse_number = 0);
std::string first_part(int verse_number);
std::string second_part(int verse_number);

} // namespace beer_song
