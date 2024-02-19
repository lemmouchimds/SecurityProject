namespace SecurityAPI
{
    public record Message(string user, string toUser, string messageText, DateTime time);

    public static class CoreApp
    {
        public static List<Message> messages = new List<Message>();

        public static void AddMessage(Message message)
        {
            messages.Add(message);
        }

        public static List <Message> GetMessages()
        {
            return messages;
        }
    }
}
