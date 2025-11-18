using System;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("I've been challenged to a CSS BATTLE by Web Dev Simplified", "Kevin Powell", 2541);
        video1.AddComment(new Comment("Chiky", "ima start using box-shadow for literally everything"));
        video1.AddComment(new Comment("Code-blue", "box-shadow should be the hello world equivalent of CSS"));
        video1.AddComment(new Comment("Isaac", "I really love watching these ones! It would be really cool to have you guys talk about your approaches together either after each battle or at the end. Love to see it. Kevin you are the best!"));
        videos.Add(video1);

        Video video2 = new Video("I Challenged An Expert Designer To A CSS Battle", "Web Dev Simplified", 2755);
        video2.AddComment(new Comment("Tiimedarts", "Hahaha 😂 Adrian is on point about Kyle's hair. I get jealous everytime."));
        video2.AddComment(new Comment("Henrique", "We need Kyle Vs Brad CSS battle or Kyle Vs dev ed...this battle will be epic"));
        video2.AddComment(new Comment("Malakisi", "We need more of these videos. 🤩"));
        video2.AddComment(new Comment("Elias", "this makes me feel alot better about my css skills"));
        videos.Add(video2);

        Video video3 = new Video("How I Code Apps SOLO That Actually Make Money (Idea + Build + Marketing Guide)", "Your Average Tech Bro", 793);
        video3.AddComment(new Comment("Anderson", "This is an extremely mature take on how software is developed. Excellent video I am actually inspired to go clone an app"));
        video3.AddComment(new Comment("Jose", "I love your pragmatism, the difference between getting something done and getting in the weeds and never shipping that side project."));
        video3.AddComment(new Comment("Minds", "Built my first app after watching your video"));
        videos.Add(video3);

        foreach (Video video in videos)
        {
            Console.WriteLine($"\nVideo Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthInSeconds} seconds");

            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}\n");

            Console.WriteLine("--- Comments --- \n");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.CommenterName}: {comment.Text}");
            }

        }
    }
}