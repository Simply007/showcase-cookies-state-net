// <auto-generated>
// This code was generated by a kontent-generators-net tool
// (see https://github.com/kontent-ai/model-generator-net).
//
// Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// For further modifications of the class, create a separate file with the partial class.
// </auto-generated>

using System;
using System.Collections.Generic;
using Kontent.Ai.Delivery.Abstractions;

namespace KontentAiModels
{
    public partial class LinkedItemTesting : IContentItem
    {
        public const string Codename = "linked_item_testing";
        public const string AtMostOneMessageCodename = "at_most_one_message";
        public const string ExactlyOneMessageCodename = "exactly_one_message";
        public const string JustMessagesCodename = "just_messages";
        public const string NonGenerticItemsCodename = "non_genertic_items";

        public IEnumerable<IContentItem> AtMostOneMessage { get; set; }
        public IEnumerable<IContentItem> ExactlyOneMessage { get; set; }
        public IEnumerable<IContentItem> JustMessages { get; set; }
        public IEnumerable<IContentItem> NonGenerticItems { get; set; }
        public IContentItemSystemAttributes System { get; set; }
    }
}