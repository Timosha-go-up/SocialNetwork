using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.BLL.Models
{
    public class MyValidationResult
    {
        public bool IsValid => Errors.Count == 0;
        public List<string> Errors { get; } = new List<string>();

        public void AddError(string message) => Errors.Add(message);

        public void AddErrors(IEnumerable<string> messages)
        {
            Errors.AddRange(messages);
        }
    }

}
