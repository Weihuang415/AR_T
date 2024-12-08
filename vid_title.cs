using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class vid_title : MonoBehaviour
{

    [SerializeField]
    // private title_effect scrambleEffect; // Reference to the TextScrambleEffect


    public Transform textParent; // Parent object to organize all text objects
    public GameObject textPrefab; // Prefab for text objects (e.g., 3D TextMesh or TextMeshPro)

    private List<GameObject> displayedTitles = new List<GameObject>();
    private List<string> videoTitles = new List<string>
    {
        "Nam June Paik: Electronic Superhighway",
        "SMASHING A WALL OF GIANT TVS! DESTROYING ELECTRONICS!",
        "Electromagnetic Festival Music in Neo Tokyo",
        "Nippon TV Official [Costume Grand Prix]: Go with Finger Joints",
        "Outrage After Wedding Cake Is Dropped On The Ground | Cake Boss",
        "Massive Trump sculpture draws interest",
        "Yoga For Low Back and Hamstrings  |  30-Minute Yoga",
        "Guided Meditation For Reprogramming Your Mind",
        "17 Weird Things Teenagers Do | Smile Squad Comedy",
        "ThetaHealing Seven Planes of Existence",
        "101 SUPER Weird Cats | AFV Funniest Cat Videos 2018",
        "King Penguins Leaving Exhibit - Cincinnati Zoo",
        "Nippon TV Official [Costume Grand Prix]: Heart",
        "Global Warming 101 | National Geographic",
        "Donald Trump Believes Climate Change Is A Hoax | All In | MSNBC",
        "The Chinese Government is Really Stupid",
        "The Mini Adventures of Winnie the Pooh: Stout and Round",
        "Vanellope meets Disney Princesses | Wreck-It Ralph 2: Ralph Breaks the Internet  | Animated Stories",
        "Mickey and Donald Have a Farm | S4 E1 | Full Episode | Mickey Mouse Clubhouse | @disneyjr",
        "Some Things to know about the CalArts Character Animation Program before spending 55k$/Year",
        "Welcome to CalArts",
        "All Artists Are Thieves",
        "HILARIOUS AND CRAZIEST COLLEGE MOMENTS COMPILATION COLLEGE PARTIES FUNNY MOMENTS COMPILATION",
        "dorm room tour",
        "Don't Let Your Mattress Steal Your Sleep - Purple",
        "5 Simple Tips For Getting a Good Night's Sleep",
        "Minecraft Speedrunner VS 3 Hunters FINALE",
        "Avenged Sevenfold - Nightmare [Official Music Video]",
        "What Happened to Japanese Horror? | Video Essay",
        "Stranger Things 5 | Title Tease | Netflix",
        "The Citizens of Halloween - This Is Halloween (From Tim Burton's \"The Nightmare Before Christmas\")",
        "PUMPKIN | How Does it Grow?",
        "Deep Dish 'Pumpkin Pie' - The Best You'll Ever Make!",
        "Soft and Chewy Chocolate Chip Cookies Recipe",
        "ASMR Apothecary Lotions and Potions (no talking, bubbling water, measuring, weighing, 1800s)",
        "Palm Beach Magician Gary Goodman",
        "Sadhguru On How to Manifest What You Really Want",
        "The Nun Clips Don't Stop Praying",
        "Ancient Greece 101 | National Geographic",
        "Making a block of perfectly clear ice",
        "Mission: Impossible The Final Reckoning | Teaser Trailer (2025 Movie) - Tom Cruise",
        "Netflix Intro Sound Variations In 60 Seconds",
        "MacBook Pro Announcement - October 30",
        "Why \"GOOGLE\" Is Actually Misspelled (EXPLAINED)",
        "15 Crazy Japanese Inventions That Actually Exist",
        "Japanese Unnecessary Inventions, useless inventions book,cool inventions, world's dumbest inventions",
        "The Coding Train!",
        "Coding Challenge 125: Fourier Series",
        "[ITP] Talent ShowCase 12-12-08",
        "New York City LIVE Manhattan on Tuesday (November 12, 2024)",
        "10 Most Famous Pieces of Art you MUST SEE in the MoMA",
        "Turning Ordinary Actions into Art with Bruce Nauman | Art21",
        "Explaining Digital Video: Formats, Codecs & Containers",
        "roseBrand",
        "Community unveils Burbank's first Armenian-themed mural",
        "Los Angeles 1960s, Hollywood and Downtown | 4k and Remastered",
        "Beach View: 3 Hours of Bora Bora Ambience & Soft Ocean Sounds",
        "Sunset Rollercoaster My Jinji (Live from YuChen Studio)",
        "Huge Awesome Park With Sliding Hills!",
        "The Only Dog Leash You'll Ever Need",
        "How Central Park Was Created Entirely By Design and Not By Nature | Architectural Digest",
        "Happy New Year NYC",
        "Cabaret Eddie Redmayne | 2024 Tony Awards (Full Performance)",
        "Mischa Maisky - Haydn - Cello Concerto No 1 in C major",
        "Weird Al Yankovic conducts the Jr. Philharmonic",
        "Cardio Power & Resistance",
        "Lesson 1: How to place the fingers on the keyboard. Typing Course.",
        "Chiikawa Usagi",
        "What is an X-ray? #medicaleducation"
    };

    public void DisplayTitle(int index)
    {
        // Ensure prefab is active before instantiating
        textPrefab.SetActive(true);

        // Instantiate and position 3D text under the image tracking target
        GameObject textObject = Instantiate(textPrefab, textParent);

        // Position the text object dynamically
        float verticalOffset = index * 0.07f; // Stack vertically
        textObject.transform.localPosition = new Vector3(0, verticalOffset, 0); // Relative to textParent

        // Set the text for the 3D object
        var textMesh = textObject.GetComponent<TextMesh>();
        textMesh.text = videoTitles[index];

        // Add the displayed text object to the list for tracking
        displayedTitles.Add(textObject);
    }

    public void UpdateAllTitles(string newText)
    {
        // Update all displayed titles to new text
        foreach (var titleObject in displayedTitles)
        {
            if (titleObject != null)
            {
                var textMesh = titleObject.GetComponent<TextMesh>();
                textMesh.text = newText;
            }
        }
    }

    public void HideTitle(int index)
    {
        textPrefab.SetActive(false);
    }



}