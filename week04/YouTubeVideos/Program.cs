using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<YouTubeVideo> videos = new List<YouTubeVideo>();

        YouTubeVideo video1 = new YouTubeVideo("C# Tutorial for Beginners", "John Doe", 600, 1000000, 50000, 2000);
        video1.Comments.Add(new Comment("Alice", "Great tutorial!"));
        video1.Comments.Add(new Comment("Bob", "Very helpful, thanks!"));

        YouTubeVideo video2 = new YouTubeVideo("Learn Python in 10 Minutes", "Jane Smith", 600, 2000000, 100000, 5000);
        video2.Comments.Add(new Comment("Charlie", "This is amazing!"));
        video2.Comments.Add(new Comment("Dave", "I learned so much from this video."));

        YouTubeVideo video3 = new YouTubeVideo("JavaScript Basics", "Emily Johnson", 600, 1500000, 75000, 3000);
        video3.Comments.Add(new Comment("Eve", "Thanks for the clear explanation!"));
        video3.Comments.Add(new Comment("Frank", "This video helped me a lot!"));

        YouTubeVideo video4 = new YouTubeVideo("Web Development with React", "Michael Brown", 600, 1200000, 60000, 2500);
        video4.Comments.Add(new Comment("Grace", "Excellent content!"));
        video4.Comments.Add(new Comment("Henry", "This is exactly what I needed."));

        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);
        videos.Add(video4);

        foreach (YouTubeVideo video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
            Console.WriteLine($"Views: {video.NumberOfViews}");
            Console.WriteLine($"Likes: {video.NumberOfLikes}");
            Console.WriteLine($"Dislikes: {video.NumberOfDislikes}");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");
            foreach (Comment comment in video.Comments)
            {
                Console.WriteLine($"\t{comment.CommenterName}: {comment.CommentText}");
            }
            Console.WriteLine();
        }
    }
}
