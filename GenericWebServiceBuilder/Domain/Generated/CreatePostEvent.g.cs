//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Domain
{
    using System;
    
    
    public class CreatePostEvent
    {
        
        private Post _Post;
        
        private CreatePostEvent(Post Post)
        {
            this.Post = Post;
        }
        
        public Post Post
        {
            get
            {
                return this._Post;
            }
            set
            {
                this.Post = Post;
            }
        }
    }
}
