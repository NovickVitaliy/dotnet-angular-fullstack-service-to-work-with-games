import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class QuoteService {
  gameQuotes = [
    { quote: "I am what the gods have made me!", author: "Kratos, God of War II" },
    { quote: "The hands of death could not defeat me. The sisters of fate could not hold me. And you will not see the end of this day!", author: "Kratos, God of War III" },
    { quote: "Boy!", author: "Kratos, God of War (2018)" },
    { quote: "The cycle ends here. We must be better than this.", author: "Kratos, God of War (2018)" },
    { quote: "I was trying to teach you responsibility!", author: "Kratos, God of War (2018)" },
    { quote: "With great power, comes great responsibility.", author: "Uncle Ben's famous quote, various Spider-Man games" },
    { quote: "My name is Miles Morales, and I'm Spider-Man.", author: "Miles Morales, Spider-Man: Miles Morales" },
    { quote: "I'm not an expert or anything, but I think it's in the way that you ask her!", author: "Peter Parker, Spider-Man (PS4)" },
    { quote: "Everyone has a part of themselves they hide. Even from the people they love most.", author: "Mary Jane Watson, Spider-Man (PS4)" },
    { quote: "We're all hunting something.", author: "Aloy, Horizon Zero Dawn" },
    { quote: "Your past doesn't define you. Your actions do.", author: "Ellie, The Last of Us Part II" },
    { quote: "This is your story. It's a good one.", author: "Atreus, God of War (2018)" },
    { quote: "Hope is what makes us strong. It is why we are here. It is what we fight with when all else is lost.", author: "God of War (2018)" },
    { quote: "Finish the fight.", author: "Master Chief, Halo 3" },
    { quote: "Wake up, John.", author: "Cortana, Halo 4" },
    { quote: "A hero need not speak. When he is gone, the world will speak for him.", author: "Halo 4" },
    { quote: "This is your destiny.", author: "The Stranger, Destiny" },
    { quote: "It's a-me, Mario!", author: "Mario, Super Mario series" },
    { quote: "Hey! Listen!", author: "Navi, The Legend of Zelda: Ocarina of Time" },
    { quote: "I'm really feeling it!", author: "Shulk, Xenoblade Chronicles" },
    { quote: "It's not about the destination, but the journey.", author: "Super Smash Bros. series" },
  ];

  constructor() { }

  getRandomQuote(){
    return this.gameQuotes[Math.floor(Math.random() * this.gameQuotes.length)];
  }
}
