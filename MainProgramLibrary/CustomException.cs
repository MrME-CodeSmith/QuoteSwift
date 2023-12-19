using System;
using System.Collections.Generic;
using System.Text;

namespace MainProgramLibrary
{
    public class FeedbackException : Exception
    {
        public string FeedbackType { get; set; }
        public int FeedbackId { get; set; }

        public FeedbackException() { }

        public FeedbackException(string message) : base(message) { }

        public FeedbackException(string message, Exception inner) : base(message, inner) { }

        public FeedbackException(string message, string feedbackType, int feedbackId) : base(message)
        {
            FeedbackType = feedbackType;
            FeedbackId = feedbackId;
        }
    }

    public class GeneralErrorException : Exception
    {
        public GeneralErrorException() { }

        public GeneralErrorException(string message) : base(message) { }

        public GeneralErrorException(string message, Exception inner) : base(message, inner) { }
    }


}
