//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Domain.Users
{
    using System;
    
    
    public class UserUpdateNameEvent : DomainEventBase
    {
        
        public String Name { get; private set; }
        
        private UserUpdateNameEvent() : 
                base(Guid.Empty)
        {
        }
        
        public UserUpdateNameEvent(String Name, Guid EntityId) : 
                base(EntityId)
        {
            this.Name = Name;
        }
    }
}
