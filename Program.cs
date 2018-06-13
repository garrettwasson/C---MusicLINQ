using System;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Collections to work with
            List<Artist> Artists = JsonToFile<Artist>.ReadJson();
            List<Group> Groups = JsonToFile<Group>.ReadJson();

            //========================================================
            //Solve all of the prompts below using various LINQ queries
            //========================================================

            //There is only one artist in this collection from Mount Vernon, what is their name and age?

            var foundArtist = from artist in Artists
                              where artist.Hometown == "Mount Vernon"
                              select artist;
            foreach (var artist in foundArtist)
            {
                Console.WriteLine($"This artist from Mount Vernon is {artist.RealName} and is {artist.Age}");
            }

            //Who is the youngest artist in our collection of artists?

            var allArtists = from artist in Artists 
                             select artist;
            var youngAge = (from artist in Artists select artist.Age).Min();
            foreach (var artist in allArtists)
            {
                if (artist.Age == youngAge)
                {
                    Console.WriteLine($"The youngest artist is {artist.RealName} who is {artist.Age}");
                }
            }

            //Display all artists with 'William' somewhere in their real name
            
            Console.WriteLine("Every artist who contains 'William' somehwere in their real name are:");
            var artistWilliam = from artist in Artists
                                 where artist.RealName.Contains("William")
                                 select artist;
            foreach (var artist in artistWilliam)
            {
                Console.WriteLine(artist.RealName);
            }
            
            // Display all groups with names less than 8 characters in length.
            
            var shortGroups = from member in Groups
                                 where member.GroupName.Length < 8
                                 select member;
            Console.WriteLine("Every groups with less than 8 characters in their name(s) are:");
            foreach (var member in shortGroups)
            {
                Console.WriteLine($"Group: {member.GroupName}");
            }

            //Display the 3 oldest artist from Atlanta
            
            var oldestArtists = from artist in Artists
                                where artist.Hometown == "Atlanta"
                                orderby artist.Age descending
                                select artist;
            Console.WriteLine("The three oldest artists from Atlanta are:");
            foreach (var artist in oldestArtists.Take(3))
            {
                Console.WriteLine($"Name: {artist.RealName} Age: {artist.Age} Hometown: {artist.Hometown}");
            }
        }
    }
}