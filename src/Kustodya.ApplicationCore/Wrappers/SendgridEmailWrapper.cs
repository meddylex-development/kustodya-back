using Kustodya.Shared.Wrappers;
using System;

namespace Kustodya.Shared.Wrappers
{
    public class SendgridEmailWrapper
    {
        public SendgridEmailWrapper()
        {
            personalizations = new PersonalizationWrapper[1];
            personalizations[0] = new PersonalizationWrapper();
            content = new ContentWrapper[1];
            content[0] = new ContentWrapper();
            from = new SenderWrapper();
        }

        public ContentWrapper[] content { get; set; }
        public SenderWrapper from { get; set; }
        public PersonalizationWrapper[] personalizations { get; set; }
        public ObjectAttachmentWrapper[] attachments { get; set; }

        public void AddAttachment(ObjectAttachmentWrapper file)
        {
            if (attachments == null)
            {
                attachments = new ObjectAttachmentWrapper[1];
                attachments[0] = file;
            }
            else 
            {
                var newAttta = new ObjectAttachmentWrapper[attachments.Length + 1];
                Array.Copy(attachments, 0, newAttta, 0, attachments.Length);
                newAttta[attachments.Length + 1] = file;

                attachments = newAttta;
            }
        }
    }
}