using System;
public class YouTubeVideo
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthInSeconds { get; set; }
    public int NumberOfViews { get; set; }
    public int NumberOfLikes { get; set; }
    public int NumberOfDislikes { get; set; }

    public List<Comment> Comments { get; set; }

    public YouTubeVideo(string title, string author, int lengthInSeconds, int numberOfViews, int numberOfLikes, int numberOfDislikes)
    {
        Title = title;
        Author = author;
        LengthInSeconds = lengthInSeconds;
        NumberOfViews = numberOfViews;
        NumberOfLikes = numberOfLikes;
        NumberOfDislikes = numberOfDislikes;
        Comments = new List<Comment>();
    }

    public int GetNumberOfComments()
    {
        return Comments.Count;
    }
}

public class Comment
{
    public string CommenterName { get; set; }
    public string CommentText { get; set; }

    public Comment(string commenterName, string commentText)
    {
        CommenterName = commenterName;
        CommentText = commentText;
    }
}